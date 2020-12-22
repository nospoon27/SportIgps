using Application.Extensions;
using Application.Features.Common;
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
    public class GetAllPagedAbonementLimitsHandler : CommonHandler, IRequestHandler<GetAllPagedAbonementLimitsQuery, PagedResponse<IList<GetAllPagedAbonementLimitsResponse>>>
    {
        public GetAllPagedAbonementLimitsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<PagedResponse<IList<GetAllPagedAbonementLimitsResponse>>> Handle(GetAllPagedAbonementLimitsQuery request, CancellationToken cancellationToken)
        {
            var items = (await _unitOfWork.GetRepository<AbonementLimit>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<GetAllPagedAbonementLimitsResponse>(s),
                sieve: request)).ToPagedResponse();
            return items;
        }
    }
}
