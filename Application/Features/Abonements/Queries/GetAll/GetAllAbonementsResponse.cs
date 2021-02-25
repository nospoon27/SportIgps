using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Abonements.Queries.GetAll
{
    public class GetAllAbonementsResponse
    {
        public int Id { get; set; }
        public bool IsChild { get; set; }
        /// <summary>
        /// Ограниченность
        /// </summary>
        public int VisitAmount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AbonementLimitId { get; set; }
        public double Price { get; set; }
        public string WorkoutName { get; set; }
        public string WorkoutDescription { get; set; }
        public int WorkoutId { get; set; }
    }
}
