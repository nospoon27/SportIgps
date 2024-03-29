﻿using Application.Features.DTOs;
using Application.Features.Sports.Commands.Create;
using Application.Features.Sports.Commands.DeleteSportById;
using Application.Features.Sports.Commands.UpdateSport;
using Application.Features.Sports.Queries.GetAll;
using Application.Features.Sports.Queries.GetAllPaged;
using Application.Features.Sports.Queries.GetById;
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
    /// Виды спорта
    /// </summary>
    public class SportsController : BaseCrudApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<SportDTO>>> GetById([FromRoute] GetByIdSportQuery request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<SportDTO>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllSportsQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IList<SportDTO>>>> GetAllPaged(
            [FromQuery] GetAllPagedSportsQuery request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult<Response<int>>> Create([FromBody] CreateSportCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<int>>> Update([FromRoute] int id, [FromBody] UpdateSportCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteSportByIdCommand() { Id = id }));
        }
    }
}
