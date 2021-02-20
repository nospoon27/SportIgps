using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Abonement : BaseEntity
    {
        /// <summary>
        /// Категория возрастная
        /// </summary>
        public bool IsChild { get; set; }
        /// <summary>
        /// Ограниченность
        /// </summary>
        public AbonementLimit AbonementLimit { get; set; }
        public int? AbonementLimitId { get; set; }
        public double Price { get; set; }
        public Workout Workout { get; set; }
        public int? WorkoutId { get; set; }
        public WorkoutGroup WorkoutGroup { get; set; }
        public int? WorkoutGroupId { get; set; }
    }
}
