using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ScheduleEvents.Queries.GetScheduleEventByWorkoutGroup.DTOs
{
    public class ScheduleTrainerDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
    }
}
