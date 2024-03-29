﻿using Application.Exceptions;
using Application.Features.Abonements.Commands.CreateAbonement;
using Application.Features.Abonements.Commands.DeleteAbonementById;
using Application.Features.Abonements.Commands.UpdateAbonement;
using Application.Features.Abonements.Queries.GetAll;
using Application.Features.Abonements.Queries.GetAllPaged;
using Application.Features.Abonements.Queries.GetById;
using Application.Features.DTOs;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Common;

namespace Web.API.Controllers
{
    /// <summary>
    /// Абонементы
    /// </summary>
    public class AbonementsController : BaseCrudApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<AbonementDTO>>> GetById([FromRoute] GetByIdAbonementQuery request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet]
        public async Task<ActionResult<Response<IList<AbonementDTO>>>> GetAllPaged([FromQuery] GetAllPagedAbonementsQuery request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<AbonementDTO>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAbonementsQuery()));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<int>>> Update([FromRoute] int id, [FromBody] UpdateAbonementCommand command)
        {
            if (id != command.Id) BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAbonementCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] DeleteAbonementByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
