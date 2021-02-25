using Application.Features.DTOs;
using Application.Features.Workouts.Commands.Create;
using Application.Features.Workouts.Queries.GetAll;
using Application.Features.Workouts.Queries.GetAllPaged;
using Application.Features.Workouts.Queries.GetById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class WorkoutMapper : Profile
    {
        public WorkoutMapper()
        {
            CreateMap<CreateWorkoutCommand, Workout>().ReverseMap();

            CreateMap<Workout, WorkoutDTO>();
        }
    }
}
