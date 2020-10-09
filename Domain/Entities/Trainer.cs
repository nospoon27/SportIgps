using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Trainer : BaseEntity
    {
        public ICollection<TrainerSpecialization> TrainerSpecialization { get; set; }
        public string Biography { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
