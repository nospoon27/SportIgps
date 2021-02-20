using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Feautures.ScheduleEvents
{
    public class Queries
    {
        public Queries()
        {
            
        }

        public async void GetScheduleEventByWorkoutGroup_ShouldGetEvents()
        {
            var mediator = new Mock<IMediator>();
            GetScheduleEventsByWorkoutGroupRequest
        }
    }
}
