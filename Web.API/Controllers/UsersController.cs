﻿using Application.Features.Users.Commands.DeleteUserById;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetCountryCodes;
using Application.Features.Users.Queries.GetGenders;
using Application.Wrappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserByIdResponse>> Get([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put([FromRoute] int id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteUserByIdCommand { Id = id }));
        }

        [HttpGet("genders")]
        public async Task<ActionResult<Response<IList<GetGendersResponse>>>> GetGenders()
        {
            return Ok(await Mediator.Send(new GetGendersQuery()));
        }

        [HttpGet("countryCodes")]
        public async Task<ActionResult<Response<IList<GetCountryCodesResponse>>>> GetCountryCodes()
        {
            return Ok(await Mediator.Send(new GetCountryCodesQuery()));
        }
    }
}
