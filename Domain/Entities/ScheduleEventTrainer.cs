using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ScheduleEventTrainer : BaseEntity
    {
        public ScheduleEvent ScheduleEvent { get; set; }
        public int ScheduleEventId { get; set; }
        public Trainer Trainer { get; set; }
        public int TrainerId { get; set; }
    }
}
