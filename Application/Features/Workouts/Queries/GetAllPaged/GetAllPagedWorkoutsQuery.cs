using Application.Parameters;
using Application.Sieve.Models;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Workouts.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutsQuery : SieveModel, IRequest<Response<IList<GetAllPagedWorkoutsResponse>>>
    {
    }
}
