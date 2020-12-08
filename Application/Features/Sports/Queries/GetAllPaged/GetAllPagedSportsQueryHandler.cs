using Application.Extensions;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
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
            var sports = (await _unitOfWork.GetRepository<Sport>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<GetAllPagedSportsResponse>(s),
                sieve: request)).ToPagedResponse();

            return sports;
        }
    }
}
