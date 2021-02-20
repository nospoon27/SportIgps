using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Queries.GetAll
{
    public class GetAllWorkoutGroupsQueryResponse : BaseEntity
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int SportId { get; set; }
    }
}
