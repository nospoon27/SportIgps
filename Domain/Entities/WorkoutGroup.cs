using Domain.Common;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class WorkoutGroup : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public IList<WorkoutGroupTrainer> WorkoutGroupTrainers { get; set; }

        [JsonIgnore]
        public IList<WorkoutGroupClient> WorkoutGroupClients { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public Sport Sport { get; set; }
        public int SportId { get; set; }
    }
}