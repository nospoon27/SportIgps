using Application.Interfaces.Services;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands.UploadFile
{
    public class UploadFileCommand : IRequest<Response<UploadFileCommandResponse>>
    {
        public IFormFile File { get; set; }
        public FilesFolder FilesFolder { get; set; }
        public string Test { get; set; }
    }
}
