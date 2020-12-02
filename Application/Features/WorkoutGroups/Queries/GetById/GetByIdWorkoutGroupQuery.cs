using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Queries.GetById
{
    public class GetByIdWorkoutGroupQuery : IRequest<Response<GetByIdWorkoutGroupQueryResponse>>
    {
        public int Id { get; set; }
    }
}
