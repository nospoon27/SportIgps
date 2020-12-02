using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Commands.Update
{
    public class UpdateWorkoutGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
