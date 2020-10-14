using Application.Features.Users.Queries.GetAll;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IList<GetAllUsersResponse>>>> Get([FromQuery] GetAllUsersQuery request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
