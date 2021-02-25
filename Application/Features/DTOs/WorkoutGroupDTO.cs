using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class WorkoutGroupDTO
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
        public LocationDTO Location { get; set; }
        public int SportId { get; set; }
        public SportDTO Sport { get; set; }
        public IList<TrainerDTO> Trainers { get; set; }
    }
}
