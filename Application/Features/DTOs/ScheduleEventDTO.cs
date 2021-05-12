using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class ScheduleEventDTO : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Duration => (End - Start).Minutes;
        public int WorkoutGroupId { get; set; }
        public WorkoutGroupDTO WorkoutGroup { get; set; }
        public bool TrainerMembershipIsChanged { get; set; }
        public IList<TrainerDTO> Trainers { get; set; }
        public int LocationId { get; set; }
        public LocationDTO Location { get; set; }
    }
}
