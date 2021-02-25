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

namespace Application.Features.AbonementLimits.Queries.GetById
{
    public class GetByIdAbonementLimitHandler : CommonHandler, IRequestHandler<GetByIdAbonementLimitQuery, Response<AbonementLimitDTO>>
    {
        public GetByIdAbonementLimitHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<AbonementLimitDTO>> Handle(GetByIdAbonementLimitQuery request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<AbonementLimit>().FindAsync(request.Id);
            return new Response<AbonementLimitDTO>(_mapper.Map<AbonementLimitDTO>(item));
        }
    }
}
