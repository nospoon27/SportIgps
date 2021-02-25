using Application.Features.DTOs;
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

namespace Application.Features.Users.Queries.GetCountryCodes
{
    public class GetCountryCodesQueryHandler : IRequestHandler<GetCountryCodesQuery, Response<IList<CountryCodeDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCountryCodesQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IList<CountryCodeDTO>>> Handle(GetCountryCodesQuery request, CancellationToken cancellationToken)
        {
            var countryCodes = await _unitOfWork.GetRepository<CountryCode>().GetAllAsync();
            return new Response<IList<CountryCodeDTO>>(_mapper.Map<IList<CountryCodeDTO>>(countryCodes));
        }
    }
}
