using Application.Features.DTOs;
using Application.Features.PersonalTrainings.Commands.Create;
using Application.Features.PersonalTrainings.Commands.Delete;
using Application.Features.PersonalTrainings.Commands.Update;
using Application.Features.PersonalTrainings.Queries.GetAll;
using Application.Features.PersonalTrainings.Queries.GetPaged;
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
    /// Персональные тренеровки
    /// </summary>
    public class PersonalTrainingController : BaseCrudApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<PersonalTrainingDTO>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPersonalTrainingsRequest()));
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IList<PersonalTrainingDTO>>>> GetPaged([FromQuery] GetPagedPersonalTrainingsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<int>>> Update([FromRoute] int id, [FromBody] UpdatePersonalTrainingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<Response<int>>> Create([FromBody] CreatePersonalTrainingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] DeletePersonalTrainingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
