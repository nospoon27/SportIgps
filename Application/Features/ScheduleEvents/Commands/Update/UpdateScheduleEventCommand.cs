using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.crud.ScheduleEvents.Commands.Update
{
    public class UpdateScheduleEventCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int WorkoutGroupId { get; set; }
        public int LocationId { get; set; }
        public IList<int> Trainers { get; set; }
    }
}
