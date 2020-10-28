using Application.Features.Users.Queries.GetCountryCodes;
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

namespace Application.Features.Users.Queries.GetGenders
{
    public class GetGendersQueryHandler : IRequestHandler<GetGendersQuery, Response<IList<GetGendersResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetGendersQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IList<GetGendersResponse>>> Handle(GetGendersQuery request, CancellationToken cancellationToken)
        {
            var genders = await _unitOfWork.GetRepository<Gender>().GetAllAsync();
            var map = _mapper.Map<IList<GetGendersResponse>>(genders);
            return new Response<IList<GetGendersResponse>>(map);
        }
    }
}
