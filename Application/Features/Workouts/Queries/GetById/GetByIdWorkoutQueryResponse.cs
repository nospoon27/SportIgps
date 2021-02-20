using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Workouts.Queries.GetById
{
    public class GetByIdWorkoutQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public Sport Sport { get; set; }
        public int SportId { get; set; }
        public Trainer Trainer { get; set; }
        public int? TrainerId { get; set; }
    }
}
