using Application.Features.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.crud.ScheduleEvents.Queries.GetAll
{
    public class GetAllScheduleEventsQuery : IRequest<Response<IList<ScheduleEventDTO>>>
    {
    }
}
