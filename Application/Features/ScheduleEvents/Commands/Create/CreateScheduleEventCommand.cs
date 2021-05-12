using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ScheduleEvents.Commands.Create
{
    public class CreateScheduleEventCommand : IRequest<Response<int>>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int WorkoutGroupId { get; set; }
        public IList<int> Trainers { get; set; }
        public int LocationId { get; set; }
    }
}
