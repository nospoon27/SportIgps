using Application.Features.DTOs;
using Application.Features.ScheduleEvents.Commands.Create;
using Application.Features.ScheduleEvents.Queries.GetScheduleEventByWorkoutGroup.DTOs;
using Application.Features.ScheduleEvents.Queries.GetWorkoutGroup;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class ScheduleEventMapper : GeneralProfile
    {
        public ScheduleEventMapper()
        {
            CreateMap<ScheduleEvent, ScheduleEventDTO>()
                .ForMember(f => f.Location, o => o.MapFrom(x => x.Location.Name));

            CreateMap<Trainer, int>()
                .ConvertUsing(src => src.Id);

            CreateMap<CreateScheduleEventCommand, ScheduleEvent>()
                .ForMember(f => f.Trainers, o => o.MapFrom(x => x.Trainers))
                .ForMember(f => f.LocationId, o => o.MapFrom(x => x.LocationId));
        }
    }
}
