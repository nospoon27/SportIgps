using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class WorkoutGroupClient : BaseEntity
    {
        public WorkoutGroup WorkoutGroup { get; set; }
        public int WorkoutGroupId { get; set; }
        public User Client { get; set; }
        public int ClientId { get; set; }
    }
}
