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

namespace Application.Features.Files.Queries.GetFileById
{
    public class GetFileByIdHandler : IRequestHandler<GetFileByIdRequest, Response<GetFileByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public GetFileByIdHandler(
            IMapper mapper,
            IFileService fileService)
        {
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<Response<GetFileByIdResponse>> Handle(GetFileByIdRequest request, CancellationToken cancellationToken)
        {
            var response = await _fileService.GetFileEntity(request.Id);
            return new Response<GetFileByIdResponse>(_mapper.Map<GetFileByIdResponse>(response));
        }
    }
}
