using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class WorkoutGroupTrainer : BaseEntity
    {
        public WorkoutGroup WorkoutGroup { get; set; }
        public int WorkoutGroupId { get; set; }
        public Trainer Trainer { get; set; }
        public int TrainerId { get; set; }
    }
}
