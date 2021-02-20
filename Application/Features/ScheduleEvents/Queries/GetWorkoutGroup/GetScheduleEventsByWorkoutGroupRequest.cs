using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ScheduleEvents.Queries.GetWorkoutGroup
{
    public class GetScheduleEventsByWorkoutGroupRequest : IRequest<Response<IList<GetScheduleEventsByWorkoutGroupResponse>>>
    {
        public int WorkoutGroupId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
