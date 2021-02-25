using Application.Features.Abonements.Commands.CreateAbonement;
using Application.Features.Abonements.Queries.GetAll;
using Application.Features.Abonements.Queries.GetAllPaged;
using Application.Features.Abonements.Queries.GetById;
using Application.Features.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class AbonementMapper : Profile
    {
        public AbonementMapper()
        {
            CreateMap<Abonement, CreateAbonementCommand>();
            CreateMap<Abonement, AbonementDTO>();
            //.ForMember(x => x.AbonementLimit.VisitAmount, o => o.MapFrom(x => x.VisitAmount))
            //.ForMember(x => x.AbonementLimit.StartTime, o => o.MapFrom(x => x.StartTime))
            //.ForMember(x => x.AbonementLimit.EndTime, o => o.MapFrom(x => x.EndTime))
            //.ForMember(x => x.Workout.Name, o => o.MapFrom(x => x.WorkoutName))
            //.ForMember(x => x.Workout.Description, o => o.MapFrom(x => x.WorkoutDescription));
        }
    }
}
