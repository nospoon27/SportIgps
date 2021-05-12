using Application.Features.AbonementLimits.Commands.Create;
using Application.Features.AbonementLimits.Commands.Delete;
using Application.Features.AbonementLimits.Commands.Update;
using Application.Features.AbonementLimits.Queries.GetAll;
using Application.Features.AbonementLimits.Queries.GetAllPaged;
using Application.Features.AbonementLimits.Queries.GetById;
using Application.Features.DTOs;
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
    /// Ограничения абонементов
    /// </summary>
    public class AbonementLimitsController : BaseCrudApiController
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        [HttpGet("{id}")]
        public async Task<ActionResult<IList<AbonementLimitDTO>>> Get([FromRoute] GetByIdAbonementLimitQuery request)
        {
            _logger.Info("INFO INFO");
            return Ok(await Mediator.Send(request));
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IList<AbonementLimitDTO>>>> GetAllPaged([FromQuery] GetAllPagedAbonementLimitsQuery request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<AbonementLimitDTO>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAbonementLimitsQuery()));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<int>>> Update([FromRoute] int id, [FromBody] UpdateAbonementLimitCommand command)
        {
            if (id != command.Id) BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<Response<int>>> Create([FromBody] CreateAbonementLimitCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] DeleteByIdAbonementLimitCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
