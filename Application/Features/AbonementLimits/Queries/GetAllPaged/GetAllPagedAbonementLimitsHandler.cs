using Application.Extensions;
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

namespace Application.Features.AbonementLimits.Queries.GetAllPaged
{
    public class GetAllPagedAbonementLimitsHandler : CommonHandler, IRequestHandler<GetAllPagedAbonementLimitsQuery, PagedResponse<IList<AbonementLimitDTO>>>
    {
        public GetAllPagedAbonementLimitsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<PagedResponse<IList<AbonementLimitDTO>>> Handle(GetAllPagedAbonementLimitsQuery request, CancellationToken cancellationToken)
        {
            var items = (await _unitOfWork.GetRepository<AbonementLimit>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<AbonementLimitDTO>(s),
                sieve: request)).ToPagedResponse();
            return items;
        }
    }
}
