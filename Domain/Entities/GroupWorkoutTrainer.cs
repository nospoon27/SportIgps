using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class GroupWorkoutTrainer
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public User Trainer { get; set; }
        public int GroupWorkoutId { get; set; }
        public GroupWorkout GroupWorkout { get; set; }
    }
}
