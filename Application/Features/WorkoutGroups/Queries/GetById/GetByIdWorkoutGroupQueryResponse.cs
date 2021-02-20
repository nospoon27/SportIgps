using Application.Features.WorkoutGroups.Queries.DTOs;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Queries.GetById
{
    public class GetByIdWorkoutGroupQueryResponse : BaseEntity
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
        public WorkoutGroupLocationDTO Location { get; set; }
        public int SportId { get; set; }
        public WorkoutGroupSportDTO Sport { get; set; }
        public IList<WorkoutGroupsTrainerDTO> Trainers { get; set; }
    }
}
