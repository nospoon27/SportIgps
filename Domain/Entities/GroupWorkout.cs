using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class GroupWorkout : BaseEntity
    {
        public DateTime Duration { get; set; }
        public int? PeopleAmount { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public double Price { get; set; }

        public IList<User> Trainers { get; set; }
        public IList<User> Clients { get; set; }
    }
}
