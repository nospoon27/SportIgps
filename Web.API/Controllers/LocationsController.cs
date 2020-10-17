using Application.Features.Locations.Commands.CreateLocation;
using Application.Features.Locations.Commands.DeleteLocationById;
using Application.Features.Locations.Commands.UpdateLocation;
using Application.Features.Locations.Queris.GetAll;
using Application.Features.Locations.Queris.GetAllPaged;
using Application.Features.Locations.Queris.GetById;
using Application.Wrappers;
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
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<ActionResult<Response<IList<GetAllLocationsResponse>>>> GetAll([FromQuery] GetAllLocationsQuery request)
        {
            return Ok(await Mediator.Send(request));
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
        /// Все локации страницами
        /// </summary>
        /// <param name="query">Фильтр страницы</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Response<GetAllPagedLocationsResponse>>> GetAllPaged([FromQuery] GetAllPagedLocationsQuery query)
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
        public async Task<ActionResult<Response<int>>> Delete([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteLocationByIdCommand { Id = id }));
        }
    }
}
