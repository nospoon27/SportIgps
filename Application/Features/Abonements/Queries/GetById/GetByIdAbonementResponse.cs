using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abonements.Queries.GetById
{
    public class GetByIdAbonementResponse
    {
        public bool IsChild { get; set; }
        public AbonementLimit AbonementLimit { get; set; }
        public int AbonementLimitId { get; set; }
        public double Price { get; set; }
        public Workout Workout { get; set; }
        public int WorkoutId { get; set; }
    }
}
