using Application.Features.AbonementLimits.Commands.Create;
using Application.Features.AbonementLimits.Commands.Delete;
using Application.Features.AbonementLimits.Commands.Update;
using Application.Features.AbonementLimits.Queries.GetAll;
using Application.Features.AbonementLimits.Queries.GetAllPaged;
using Application.Features.AbonementLimits.Queries.GetById;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class AbonementLimitsController : BaseApiController
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        [HttpGet("{id}")]
        public async Task<ActionResult<IList<GetByIdAbonementLimitResponse>>> Get([FromRoute] GetByIdAbonementLimitQuery request)
        {
            _logger.Info("INFO INFO");
            return Ok(await Mediator.Send(request));
        }

        [HttpGet]
        public async Task<ActionResult<Response<IList<GetAllPagedAbonementLimitsResponse>>>> GetAllPaged([FromQuery] GetAllPagedAbonementLimitsQuery request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<GetAllAbonementLimitsResponse>>>> GetAll()
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
        public async Task<ActionResult<int>> Create([FromBody] CreateAbonementLimitCommand command)
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
