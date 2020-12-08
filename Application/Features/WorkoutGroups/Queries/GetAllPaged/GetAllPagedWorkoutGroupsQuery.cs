using Application.Parameters;
using Application.Sieve.Models;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutGroupsQuery : SieveModel, IRequest<Response<IList<GetAllPagedWorkoutGroupsResponse>>>
    {

    }
}
