using Application.Sieve.Models;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AbonementLimits.Queries.GetAllPaged
{
    public class GetAllPagedAbonementLimitsQuery : SieveModel, IRequest<PagedResponse<IList<GetAllPagedAbonementLimitsResponse>>>
    {
    }
}
