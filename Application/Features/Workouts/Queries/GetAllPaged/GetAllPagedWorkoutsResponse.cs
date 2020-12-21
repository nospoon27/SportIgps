﻿using Domain.Common;
using Domain.Entities;

namespace Application.Features.Workouts.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutsResponse : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public Sport Sport { get; set; }
        public int SportId { get; set; }
        public WorkoutGroup WorkoutGroup { get; set; }
        public int WorkoutGroupId { get; set; }
        public Trainer Trainer { get; set; }
        public int? TrainerId { get; set; }
    }
}