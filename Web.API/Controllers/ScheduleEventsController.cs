using Application.Features.ScheduleEvents.Commands.Create;
using Application.Features.ScheduleEvents.Queries.GetWorkoutGroup;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class ScheduleEventsController : BaseApiController
    {
        [HttpGet("{workoutGroup}/{start}/{end}")]
        public async Task<ActionResult> GetScheduleEventsByWorkoutGroup([FromRoute] GetScheduleEventsByWorkoutGroupRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult> AddScheduleEvent([FromBody] CreateScheduleEventCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
