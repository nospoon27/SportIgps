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
            CreateMap<ScheduleEvent, GetScheduleEventsByWorkoutGroupResponse>()
                .ForMember(f => f.Location, o => o.MapFrom(x => x.Location.Name));

            CreateMap<Trainer, ScheduleTrainerDTO>()
                .ForMember(f => f.Id, o => o.MapFrom(x => x.Id))
                .ForMember(f => f.UserId, o => o.MapFrom(x => x.User.Id))
                .ForMember(f => f.Avatar, o =>
                {
                    o.PreCondition(x => x.User.UserPhoto != null);
                    o.MapFrom(x => x.User.UserPhoto.SmallUrl);
                });

            CreateMap<Trainer, int>()
                .ConvertUsing(src => src.Id);

            CreateMap<CreateScheduleEventCommand, ScheduleEvent>()
                .ForMember(f => f.Trainers, o => o.MapFrom(x => x.Trainers))
                .ForMember(f => f.LocationId, o => o.MapFrom(x => x.LocationId));
        }
    }
}
