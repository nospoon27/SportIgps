using Application.Extensions;
using Application.Interfaces.UnitOfWork;
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

namespace Application.Features.Sports.Queries.GetAllPaged
{
    public class GetAllPagedSportsQueryHandler : IRequestHandler<GetAllPagedSportsQuery, PagedResponse<IList<GetAllPagedSportsResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllPagedSportsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IList<GetAllPagedSportsResponse>>> Handle(GetAllPagedSportsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = new PagedRequest(request.PageNumber, request.PageSize);
            var sports = (await _unitOfWork.GetRepository<Sport>().GetPagedListAsync(
                selector: s => _mapper.Map<GetAllPagedSportsResponse>(s),
                pageIndex: validFilter.PageNumber,
                pageSize: validFilter.PageSize)).ToPagedResponse();

            return sports;
        }
    }
}
