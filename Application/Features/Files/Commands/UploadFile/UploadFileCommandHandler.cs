using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Response<UploadFileCommandResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public UploadFileCommandHandler(
            IMapper mapper,
            IFileService fileService)
        {
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<Response<UploadFileCommandResponse>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var response = await _fileService.SaveFileAndReturn(request.File, request.FilesFolder);
            return new Response<UploadFileCommandResponse>(_mapper.Map<UploadFileCommandResponse>(response));
        }
    }
}
