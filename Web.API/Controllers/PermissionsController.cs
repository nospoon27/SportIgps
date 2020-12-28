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
        /// <summary>
        /// Получить все Permissions текущего пользователя
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<Response<string>>> GetCurrentUserPermissions()
        {
            return Ok(await Mediator.Send(new GetCurrentUserPermissionsQuery()));
        }

        /// <summary>
        /// Добавляет Permission к определенной роли
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize (Roles = "admin")]
        public async Task<ActionResult<Response<int>>> AddPermission(AddPermissionCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        /// <summary>
        /// Получить все Permissions
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        [Authorize (Roles = "admin")]
        public async Task<ActionResult<Response<IList<GetAllPermissionsResponse>>>> GetAll([FromQuery] GetAllPermissionsQuery request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        /// <summary>
        /// Изменить Permission
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize (Roles = "admin")]
        public async Task<ActionResult<Response<int>>> Update([FromRoute]int id, [FromBody] UpdatePermissionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Удалить по Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] DeletePermissionByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
