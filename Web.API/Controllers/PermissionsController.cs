using Application.Features.Permissions.Commands.AddPermission;
using Application.Features.Permissions.Commands.DeleteById;
using Application.Features.Permissions.Commands.UpdatePermission;
using Application.Features.Permissions.Queries.GetAll;
using Application.Features.Permissions.Queries.GetCurrentUserPermissions;
using Application.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class PermissionsController : BaseApiController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Response<string>>> GetCurrentUserPermissions()
        {
            return Ok(await Mediator.Send(new GetCurrentUserPermissionsQuery()));
        }

        [HttpPost]
        [Authorize (Roles = "admin")]
        public async Task<ActionResult<Response<int>>> AddPermission(AddPermissionCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("all")]
        [Authorize (Roles = "admin")]
        public async Task<ActionResult<Response<IList<GetAllPermissionsResponse>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPermissionsQuery()));
        }
        
        [HttpPut("{id}")]
        [Authorize (Roles = "admin")]
        public async Task<ActionResult<Response<int>>> Update([FromRoute]int id, [FromBody] UpdatePermissionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] DeletePermissionByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
