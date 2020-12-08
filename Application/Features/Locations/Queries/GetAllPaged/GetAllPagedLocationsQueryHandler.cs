using Application.Extensions;
using Application.Features.Locations.Queris.GetAllPaged;
using Application.Interfaces.UnitOfWork;
using Application.Sieve.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Locations.Queries.GetAllPaged
{
    public class GetAllPagedLocationsQueryHandler : IRequestHandler<GetAllPagedLocationsQuery, PagedResponse<IList<GetAllPagedLocationsResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISieveProcessor _sieveProcessor;
        public GetAllPagedLocationsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ISieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }
        public async Task<PagedResponse<IList<GetAllPagedLocationsResponse>>> Handle(GetAllPagedLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = (await _unitOfWork.GetRepository<Location>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<GetAllPagedLocationsResponse>(s),
                sieve: request)).ToPagedResponse();


            return locations;
        }
    }
}
