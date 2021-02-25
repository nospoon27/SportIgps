using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PersonalTraining : BaseEntity
    {
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public int ClientId { get; set; }
        public User Client { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
    }
}
