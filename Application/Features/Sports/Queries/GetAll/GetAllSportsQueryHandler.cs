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

namespace Application.Features.Sports.Queries.GetAll
{
    public class GetAllSportsQueryHandler : IRequestHandler<GetAllSportsQuery, Response<IList<GetAllSportsResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllSportsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<IList<GetAllSportsResponse>>> Handle(GetAllSportsQuery request, CancellationToken cancellationToken)
        {
            var sports = await _unitOfWork.GetRepository<Sport>().GetAllAsync();
            return new Response<IList<GetAllSportsResponse>>(_mapper.Map<IList<GetAllSportsResponse>>(sports));
        }
    }
}
