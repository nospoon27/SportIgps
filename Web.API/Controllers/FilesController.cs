using Application.Exceptions;
using Application.Features.Files.Commands.UploadFile;
using Application.Features.Files.Commands.UploadFiles;
using Application.Features.Files.Queries.GetAllFiles;
using Application.Features.Files.Queries.GetFileById;
using Application.Features.Roles.Commands.Delete;
using Application.Wrappers;
using Infrastructure.Persistence.Identity.AccessControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    public class FilesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> Test()
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "1.jpg"));
            using(var image = await Image.LoadAsync(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "1.jpg")))
            {
                image.Mutate(x => x.Resize(50, 50));
                image.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "2.jpg"));
                image.SaveAsPng(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "3.png"));
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Response<UploadFilesCommandResponse>>> UploadFiles([FromForm] UploadFilesCommand command)
        {
            var files = (await Request.ReadFormAsync()).Files;

            CheckForFilesContains(files);

            return Ok(await Mediator.Send(command));
        }

        [HttpPost("single"), DisableRequestSizeLimit]
        public async Task<ActionResult<Response<UploadFileCommandResponse>>> UploadFile([FromForm] UploadFileCommand command)
        {
            var files = (await Request.ReadFormAsync()).Files;

            CheckForFilesContains(files);
            CheckForSingleFile(files);

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

        private void CheckForSingleFile(IFormFileCollection files)
        {
            if (files.Count > 1) throw new ApiException("Файл должен быть 1");
        }

        private void CheckForFilesContains(IFormFileCollection files)
        {
            if (files.Count < 1) throw new ApiException("Ошибка при загрузке файла (файлов)");
        }
    }
}
