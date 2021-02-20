using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Workouts.Queries.GetAll
{
    public class GetAllWorkoutsQueryResponse : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int SportId { get; set; }
        public int? TrainerId { get; set; }
    }
}
