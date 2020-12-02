using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Commands.DeleteById
{
    public class DeleteWorkoutGroupByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
