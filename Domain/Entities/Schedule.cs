using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Schedule : BaseEntity
    {
        /// <summary>
        /// Время начала занятия
        /// </summary>
        public DateTime BeginAt { get; set; }
        /// <summary>
        /// Продолжительность занятия
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedAt { get; } = DateTime.Now;
    }
}
