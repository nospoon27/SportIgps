using Application.Features.crud.ScheduleEvents.Commands.Update;
using Application.Features.crud.ScheduleEvents.Queries.GetAll;
using Application.Features.crud.ScheduleEvents.Queries.GetById;
using Application.Features.crud.ScheduleEvents.Queries.GetPaged;
using Application.Features.DTOs;
using Application.Features.ScheduleEvents.Commands.Create;
using Application.Features.ScheduleEvents.Queries.GetWorkoutGroup;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.API.Common;

namespace Web.API.Controllers
{
    /// <summary>
    /// События расписания
    /// </summary>
    public class ScheduleEventsController : BaseCrudApiController
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

        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<ScheduleEventDTO>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllScheduleEventsQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IList<ScheduleEventDTO>>>> GetPaged([FromQuery] GetPagedScheduleEventsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<ScheduleEventDTO>>> GetById([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetByIdScheduleEventQuery { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<int>>> Update([FromRoute] int id, [FromBody] UpdateScheduleEventCommand command)
        {
            if (id != command.Id) return BadRequest();

            return Ok(await Mediator.Send(command));
        }
    }
}
