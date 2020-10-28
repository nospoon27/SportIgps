using Domain.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Trainer : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public bool CanBePersonal { get; set; }
        [JsonIgnore]
        public IList<WorkoutGroupTrainer> WorkoutGroupTrainers { get; set; }
    }
}