using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Queries.GetById
{
    public class GetByIdWorkoutGroupQueryResponse : BaseEntity
    {
        public string Name { get; set; }
    }
}
