using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class AbonementDTO
    {
        public bool IsChild { get; set; }
        /// <summary>
        /// Ограниченность
        /// </summary>
        public AbonementLimitDTO AbonementLimit { get; set; }
        public int? AbonementLimitId { get; set; }
        public double Price { get; set; }
        public WorkoutDTO Workout { get; set; }
        public int? WorkoutId { get; set; }
        public WorkoutGroupDTO WorkoutGroup { get; set; }
        public int? WorkoutGroupId { get; set; }
    }
}
