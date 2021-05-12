using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class PersonalTrainingDTO : BaseEntity
    {
        public int TrainerId { get; set; }
        public TrainerDTO Trainer { get; set; }
        public int ClientId { get; set; }
        public UserDTO Client { get; set; }
        public int SportId { get; set; }
        public SportDTO Sport { get; set; }
    }
}
