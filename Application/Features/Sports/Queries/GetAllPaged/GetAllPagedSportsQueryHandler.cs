using Application.Extensions;
using Application.Features.DTOs;
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
    public class GetAllPagedSportsQueryHandler : IRequestHandler<GetAllPagedSportsQuery, PagedResponse<IList<SportDTO>>>
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

        public async Task<PagedResponse<IList<SportDTO>>> Handle(GetAllPagedSportsQuery request, CancellationToken cancellationToken)
        {
            var sports = (await _unitOfWork.GetRepository<Sport>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<SportDTO>(s),
                sieve: request)).ToPagedResponse();

            return sports;
        }
    }
}
