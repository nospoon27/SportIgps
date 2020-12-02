using Application.Features.WorkoutGroups.Commands.Create;
using Application.Features.WorkoutGroups.Commands.DeleteById;
using Application.Features.WorkoutGroups.Commands.Update;
using Application.Features.WorkoutGroups.Queries.GetAll;
using Application.Features.WorkoutGroups.Queries.GetAllPaged;
using Application.Features.WorkoutGroups.Queries.GetById;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class WorkoutGroupsController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<GetByIdWorkoutGroupQueryResponse>>> GetById([FromRoute] GetByIdWorkoutGroupQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IList<GetAllPagedWorkoutGroupsQueryResponse>>>> GetPaged([FromQuery] GetAllPagedWorkoutGroupsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<GetAllWorkoutGroupsQueryResponse>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllWorkoutGroupsQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<Response<int>>> Create([FromBody] CreateWorkoutGroupCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<int>>> Update([FromRoute] int id, [FromBody] UpdateWorkoutGroupCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteWorkoutGroupByIdCommand()));
        }
    }
}
