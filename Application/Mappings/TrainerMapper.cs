using Application.Features.Trainers.Commands.Create;
using Application.Features.Trainers.Queries.GetAll;
using Application.Features.Trainers.Queries.GetAllPaged;
using Application.Features.Trainers.Queries.GetById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class TrainerMapper : Profile
    {
        public TrainerMapper()
        {
            CreateMap<CreateTrainerCommand, Trainer>();
            CreateMap<Trainer, GetAllTrainersQueryResponse>().ForPath(dest => dest.User, opt => opt.MapFrom(x => x.User));
            CreateMap<Trainer, GetAllPagedTrainersQueryResponse>();
            CreateMap<Trainer, GetByIdTrainerQueryResponse>().ReverseMap();
        }
    }
}
