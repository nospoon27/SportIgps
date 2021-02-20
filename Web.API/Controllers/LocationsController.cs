using Application.Features.Locations.Commands.CreateLocation;
using Application.Features.Locations.Commands.DeleteLocationById;
using Application.Features.Locations.Commands.UpdateLocation;
using Application.Features.Locations.Queries.GetAll;
using Application.Features.Locations.Queries.GetAllPaged;
using Application.Features.Locations.Queris.GetAllPaged;
using Application.Features.Locations.Queris.GetById;
using Application.Parameters;
using Application.Sieve.Models;
using Application.Wrappers;
using Infrastructure.Persistence.Identity.AccessControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class LocationsController : BaseApiController
    {
        /// <summary>
        /// Все локации
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<GetAllLocationsResponse>>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllLocationsQuery()));
        }

        /// <summary>
        /// Локация по id
        /// </summary>
        /// <param name="id">id локации</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<GetLocationByIdResponse>>> Get([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetLocationByIdQuery { Id = id }));
        }

        /// <summary>
        /// Локации с пагинацией и сортировкой
        /// </summary>
        /// <param name="query">Пагинация и сортировка</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedResponse<GetAllPagedLocationsResponse>>> GetAllPaged([FromQuery] GetAllPagedLocationsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Добавить локацию
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        //[Authorize(Permissions.Locations.CreateUpdateDelete)]
        public async Task<ActionResult<Response<int>>> Create([FromBody] CreateLocationCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = result.Data }, result);
        }

        /// <summary>
        /// Изменить локацию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id}")]
        //[Authorize(Permissions.Locations.CreateUpdateDelete)]
        public async Task<ActionResult<Response<int>>> Update([FromRoute] int id, [FromBody] UpdateLocationCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Удалить локацию
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        //[Authorize(Permissions.Locations.CreateUpdateDelete)]
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteLocationByIdCommand { Id = id }));
        }
    }
}
