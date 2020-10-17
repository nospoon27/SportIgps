using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Специализация тренера по спорту
    /// </summary>
    public class TrainerSpecialization : BaseEntity
    {
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int TrainerId { get; set; }
        public User Trainer { get; set; }
    }
}
