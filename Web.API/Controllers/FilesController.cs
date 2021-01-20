using Application.Features.Files.Commands.UploadFile;
using Application.Features.Files.Commands.UploadFiles;
using Application.Features.Files.Queries.GetAllFiles;
using Application.Features.Files.Queries.GetFileById;
using Application.Features.Roles.Commands.Delete;
using Application.Wrappers;
using Domain.Entities;
using Infrastructure.Persistence.Identity.AccessControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class FilesController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<Response<UploadFilesCommandResponse>>> UploadFiles([FromBody] UploadFilesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("single")]
        public async Task<ActionResult<Response<UploadFileCommandResponse>>> UploadFile([FromBody] UploadFileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("all"), Authorize(Permissions.Files.ReadAll)]
        public async Task<ActionResult> GetAllFiles([FromQuery] GetAllFilesRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFileById([FromRoute] GetFileByIdRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<int>>> DeleteFileById([FromRoute] DeleteRoleByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
