using Application.Extensions;
using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.UnitOfWork.Sorting;
using Application.Parameters;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Trainers.Queries.GetAllPaged
{
    public class GetAllPagedTrainersQueryHandler : CommonHandler, IRequestHandler<GetAllPagedTrainersQuery, PagedResponse<IList<GetAllPagedTrainersQueryResponse>>>
    {
        public GetAllPagedTrainersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<PagedResponse<IList<GetAllPagedTrainersQueryResponse>>> Handle(GetAllPagedTrainersQuery request, CancellationToken cancellationToken)
        {
            var filter = new PagedRequest(request.Page, request.PageSize);
            var trainers = (await _unitOfWork.GetRepository<Trainer>()
                .GetPagedListAsync(
                selector: s => _mapper.Map<GetAllPagedTrainersQueryResponse>(s),
                pageIndex: filter.Page,
                orderBy: s => s.OrderBy(request.Sort),
                pageSize: filter.PageSize)).ToPagedResponse();

            return trainers;
        }
    }
}
