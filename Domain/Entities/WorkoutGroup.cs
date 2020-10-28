using Domain.Common;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class WorkoutGroup : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public IList<WorkoutGroupTrainer> WorkoutGroupTrainers { get; set; }

        [JsonIgnore]
        public IList<WorkoutGroupClient> WorkoutGroupClients { get; set; }
    }
}