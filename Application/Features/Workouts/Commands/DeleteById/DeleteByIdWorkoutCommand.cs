using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Workouts.Commands.DeleteById
{
    public class DeleteByIdWorkoutCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
