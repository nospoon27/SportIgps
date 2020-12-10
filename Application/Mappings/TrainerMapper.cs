using Application.DTOs.Users;
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
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<CreateTrainerCommand, Trainer>();
            CreateMap<Trainer, GetAllTrainersQueryResponse>();
            CreateMap<Trainer, GetAllPagedTrainersResponse>();
            CreateMap<Trainer, GetByIdTrainerQueryResponse>().ReverseMap();
        }
    }
}
