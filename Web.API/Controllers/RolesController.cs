using Application.Features.Roles.Commands.Create;
using Application.Features.Roles.Commands.Delete;
using Application.Features.Roles.Commands.Update;
using Application.Features.Roles.Queries.GetAll;
using Application.Features.Roles.Queries.GetById;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class RolesController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<GetRoleByIdResponse>>> Get([FromRoute] GetRoleByIdQuery request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("all")]
        public async Task<ActionResult<Response<GetAllRolesResponse>>> Get()
        {
            return Ok(await Mediator.Send(new GetAllRolesQuery()));
        }

        [HttpPut]
        public async Task<ActionResult<Response<int>>> Update([FromRoute] int id, [FromBody] UpdateRoleCommand request)
        {
            if (id != request.Id) return BadRequest();
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult<Response<int>>> Create([FromBody] CreateRoleCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] DeleteRoleByIdCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
