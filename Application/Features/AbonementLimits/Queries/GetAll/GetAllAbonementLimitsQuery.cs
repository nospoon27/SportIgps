using Application.Features.DTOs;
using Application.Wrappers;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.AbonementLimits.Queries.GetAll
{
    public class GetAllAbonementLimitsQuery : IRequest<Response<IList<AbonementLimitDTO>>>
    {
    }
}
