using Application.Features.Files.Commands;
using Application.Features.Files.Commands.UploadFile;
using Application.Features.Files.Commands.UploadFiles;
using Application.Features.Files.Queries.GetAllFiles;
using Application.Features.Files.Queries.GetFileById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class FileMapper : Profile
    {
        public FileMapper()
        {
            CreateMap<FileEntity, UploadFilesCommandResponse>()
                .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
                .ForMember(x => x.Size, o => o.MapFrom(x => x.Size))
                .ForMember(x => x.FileName, o => o.MapFrom(x => x.Path));

            CreateMap<FileEntity, UploadFileCommandResponse>()
                .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
                .ForMember(x => x.Size, o => o.MapFrom(x => x.Size))
                .ForMember(x => x.FileName, o => o.MapFrom(x => x.Path));

            CreateMap<FileEntity, GetAllFilesResponse>();

            CreateMap<FileEntity, GetFileByIdResponse>();
        }
    }
}
