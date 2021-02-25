using Application.Features.DTOs;
using Application.Features.WorkoutGroups.Commands.Create;
using Application.Features.WorkoutGroups.Queries.GetAll;
using Application.Features.WorkoutGroups.Queries.GetAllPaged;
using Application.Features.WorkoutGroups.Queries.GetById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class WorkoutGroupMapper : Profile
    {
        public WorkoutGroupMapper()
        {
            CreateMap<CreateWorkoutGroupCommand, WorkoutGroup>().ReverseMap();
            CreateMap<WorkoutGroup, WorkoutGroupDTO>().ReverseMap();
        }
    }
}
