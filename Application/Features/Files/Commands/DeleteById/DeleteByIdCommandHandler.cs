using Application.Interfaces.Services;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands.DeleteById
{
    public class DeleteByIdCommandHandler : IRequestHandler<DeleteByIdCommand, Response<int>>
    {
        private readonly IFileService _fileService;
        public DeleteByIdCommandHandler(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<Response<int>> Handle(DeleteByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _fileService.DeleteFile(request.Id);

            return new Response<int>(response);
        }
    }
}
