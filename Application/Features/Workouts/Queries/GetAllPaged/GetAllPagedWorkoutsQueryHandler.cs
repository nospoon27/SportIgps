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

namespace Application.Features.Workouts.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutsQueryHandler : CommonHandler, IRequestHandler<GetAllPagedWorkoutsQuery, Response<IList<GetAllPagedWorkoutsQueryResponse>>>
    {
        public GetAllPagedWorkoutsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<GetAllPagedWorkoutsQueryResponse>>> Handle(GetAllPagedWorkoutsQuery request, CancellationToken cancellationToken)
        {
            var filter = new PagedRequest(request.PageNumber, request.PageSize);
            var items = (await _unitOfWork.GetRepository<Workout>()
                .GetPagedListAsync(
                selector: s => _mapper.Map<GetAllPagedWorkoutsQueryResponse>(s),
                pageIndex: filter.PageNumber,
                orderBy: s => s.OrderBy(request.Sort),
                pageSize: filter.PageSize)).ToPagedResponse();

            return items;
        }
    }
}
