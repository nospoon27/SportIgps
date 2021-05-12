using Application.Features.DTOs;
using Application.Sieve.Models;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.crud.ScheduleEvents.Queries.GetPaged
{
    public class GetPagedScheduleEventsQuery : SieveModel, IRequest<Response<IList<ScheduleEventDTO>>>
    {
    }
}
