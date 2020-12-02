using Application.Parameters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Queries.GetAll
{
    public class GetAllWorkoutGroupsQuery : IRequest<Response<IList<GetAllWorkoutGroupsQueryResponse>>>
    {
        
    }
}
