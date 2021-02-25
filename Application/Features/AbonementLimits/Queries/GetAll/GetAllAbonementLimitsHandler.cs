using Application.Features.Common;
using Application.Features.DTOs;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AbonementLimits.Queries.GetAll
{
    public class GetAllAbonementLimitsHandler : CommonHandler, IRequestHandler<GetAllAbonementLimitsQuery, Response<IList<AbonementLimitDTO>>>
    {
        public GetAllAbonementLimitsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<AbonementLimitDTO>>> Handle(GetAllAbonementLimitsQuery request, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.GetRepository<AbonementLimit>().GetAllAsync();

            return new Response<IList<AbonementLimitDTO>>(_mapper.Map<IList<AbonementLimitDTO>>(items));
        }
    }
}
