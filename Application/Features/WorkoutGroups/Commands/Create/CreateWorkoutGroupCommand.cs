using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Commands.Create
{
    public class CreateWorkoutGroupCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int SportId { get; set; }
    }
}
