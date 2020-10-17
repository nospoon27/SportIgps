using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Locations.Queris.GetAll
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, Response<IList<GetAllLocationsResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllLocationsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<IList<GetAllLocationsResponse>>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await _unitOfWork.GetRepository<Location>().GetAllAsync();
            return new Response<IList<GetAllLocationsResponse>>(_mapper.Map<IList<GetAllLocationsResponse>>(locations));
        }
    }
}
