using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ScheduleEvent : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int WorkoutGroupId { get; set; }
        public WorkoutGroup WorkoutGroup { get; set; }
        public bool TrainerMembershipIsChanged { get; set; }
        public IList<ScheduleEventTrainer> ScheduleEventTrainers { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
    }
}
