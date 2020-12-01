using Application.Features.Abonements.Commands.CreateAbonement;
using Application.Features.Abonements.Queries.GetAll;
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
            CreateMap<GetAllAbonementsQueryResponse, Abonement>()
                .ForPath(x => x.AbonementLimit, m => m.MapFrom(x => x.VisitAmount))
                .ForPath(x => x.AbonementLimit, m => m.MapFrom(x => x.StartTime))
                .ForPath(x => x.AbonementLimit, m => m.MapFrom(x => x.EndTime));
                //.ForMember(x => x.AbonementLimit.VisitAmount, o => o.MapFrom(x => x.VisitAmount))
                //.ForMember(x => x.AbonementLimit.StartTime, o => o.MapFrom(x => x.StartTime))
                //.ForMember(x => x.AbonementLimit.EndTime, o => o.MapFrom(x => x.EndTime))
                //.ForMember(x => x.Workout.Name, o => o.MapFrom(x => x.WorkoutName))
                //.ForMember(x => x.Workout.Description, o => o.MapFrom(x => x.WorkoutDescription));
        }
    }
}
