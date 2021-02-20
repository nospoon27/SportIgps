using Application.Features.ScheduleEvents.Queries.GetScheduleEventByWorkoutGroup.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ScheduleEvents.Queries.GetWorkoutGroup
{
    public class GetScheduleEventsByWorkoutGroupResponse
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Duration => (End - Start).Minutes;
        public int WorkoutGroupId { get; set; }
        public bool TrainerMembershipIsChanged { get; set; }
        public IList<ScheduleTrainerDTO> Trainers { get; set; }
        public string Location { get; set; }
    }
}
