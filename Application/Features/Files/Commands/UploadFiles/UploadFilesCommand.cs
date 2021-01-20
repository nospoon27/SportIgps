using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands.UploadFiles
{
    public class UploadFilesCommand : IRequest<Response<IList<UploadFilesCommandResponse>>>
    {
        public UploadFilesCommand(List<IFormFile> files)
        {
            Files = files;
        }

        public List<IFormFile> Files { get; set; }
    }
}
