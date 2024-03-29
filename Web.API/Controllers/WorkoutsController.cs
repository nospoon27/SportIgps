﻿using Application.Features.DTOs;
using Application.Features.Workouts.Commands.Create;
using Application.Features.Workouts.Commands.DeleteById;
using Application.Features.Workouts.Commands.Update;
using Application.Features.Workouts.Queries.GetAll;
using Application.Features.Workouts.Queries.GetAllPaged;
using Application.Features.Workouts.Queries.GetById;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Common;

namespace Web.API.Controllers
{
    /// <summary>
    /// Занятия
    /// </summary>
    public class WorkoutsController : BaseCrudApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<WorkoutDTO>>> GetById([FromRoute] GetByIdWorkoutQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IList<WorkoutDTO>>>> GetPaged([FromQuery] GetAllPagedWorkoutsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<WorkoutDTO>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllWorkoutsQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<Response<int>>> Create([FromBody] CreateWorkoutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<int>>> Update([FromRoute] int id, [FromBody] UpdateWorkoutCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteByIdWorkoutCommand()));
        }
    }
}
