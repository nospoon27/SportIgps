using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Workout : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public Sport Sport { get; set; }
        public int SportId { get; set; }
    }
}
