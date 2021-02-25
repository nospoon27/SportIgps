using Application.Features.DTOs;
using Application.Features.Trainers.Commands.Create;
using Application.Features.Trainers.Commands.DeleteById;
using Application.Features.Trainers.Commands.Update;
using Application.Features.Trainers.Queries.GetAllPaged;
using Application.Features.Trainers.Queries.GetById;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class TrainersController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<TrainerDTO>>> GetById([FromRoute] GetByIdTrainerQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IList<TrainerDTO>>>> GetPaged([FromQuery] GetAllPagedTrainersQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<TrainerDTO>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPagedTrainersQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<Response<int>>> Create([FromBody] CreateTrainerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<int>>> Update([FromRoute] int id, [FromBody] UpdateTrainerCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteByIdTrainerCommand()));
        }
    }
}
