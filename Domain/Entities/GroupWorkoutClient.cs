using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class GroupWorkoutClient
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public User Client { get; set; }
        public int GroupWorkoutId { get; set; }
        public GroupWorkout GroupWorkout { get; set; }
    }
}
