using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abonements.Queries.GetAllPaged
{
    public class GetAllPagedAbonementsResponse : BaseEntity
    {
        public bool IsChild { get; set; }
        public AbonementLimit AbonementLimit { get; set; }
        public int AbonementLimitId { get; set; }
        public double Price { get; set; }
        public Workout Workout { get; set; }
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }
        public string WorkoutDescription { get; set; }
    }
}
