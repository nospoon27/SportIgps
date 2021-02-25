using Application.Features.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Workouts.Queries.GetById
{
    public class GetByIdWorkoutQuery : IRequest<Response<WorkoutDTO>>
    {
        public int Id { get; set; }
    }
}
