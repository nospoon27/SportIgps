using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands.UploadFiles
{
    public class UploadFilesCommandHandler : IRequestHandler<UploadFilesCommand, Response<IList<UploadFilesCommandResponse>>>
    {
        private IFileService _fileService;
        private readonly IMapper _mapper;
        public UploadFilesCommandHandler(
            IFileService fileService,
            IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<Response<IList<UploadFilesCommandResponse>>> Handle(UploadFilesCommand request, CancellationToken cancellationToken)
        {
            var response = await _fileService.SaveFilesAndReturn(request.Files, request.FilesFolder);
            return new Response<IList<UploadFilesCommandResponse>>(
                _mapper.Map<IList<UploadFilesCommandResponse>>(response));
        }
    }
}
