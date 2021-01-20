using Application.Features.Common;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Files.Queries.GetAllFiles
{
    public class GetAllFilesHandler : IRequestHandler<GetAllFilesRequest, Response<IList<GetAllFilesResponse>>>
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public GetAllFilesHandler(
            IFileService fileService,
            IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<Response<IList<GetAllFilesResponse>>> Handle(GetAllFilesRequest request, CancellationToken cancellationToken)
        {
            var files = await _fileService.GetAllFiles(
                request.WithDeleted 
                ? null 
                : x => x.IsActive == true);

            return new Response<IList<GetAllFilesResponse>>(
                _mapper.Map<IList<GetAllFilesResponse>>(files));
        }
    }
}
