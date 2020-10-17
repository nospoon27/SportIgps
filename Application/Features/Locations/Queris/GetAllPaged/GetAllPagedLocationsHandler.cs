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

namespace Application.Features.Locations.Queris.GetAllPaged
{
    public class GetAllPagedLocationsHandler : IRequestHandler<GetAllPagedLocationsQuery, PagedResponse<IList<GetAllPagedLocationsResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllPagedLocationsHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IList<GetAllPagedLocationsResponse>>> Handle(GetAllPagedLocationsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = new PagedRequest(request.PageNumber, request.PageSize);
            var locations = (await _unitOfWork.GetRepository<Location>()
                .GetPagedListAsync(
                selector: s => _mapper.Map<GetAllPagedLocationsResponse>(s),
                pageIndex: validFilter.PageNumber,
                pageSize: validFilter.PageSize)).ToPagedResponse();

            return locations;
        }
    }
}
