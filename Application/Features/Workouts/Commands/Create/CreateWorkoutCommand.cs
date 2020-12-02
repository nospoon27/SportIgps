using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Workouts.Commands.Create
{
    public class CreateWorkoutCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int SportId { get; set; }
        public int WorkoutGroupId { get; set; }
        public int? TrainerId { get; set; }
    }
}
