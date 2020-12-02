using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Workouts.Queries.GetAll
{
    public class GetAllWorkoutsQuery : IRequest<Response<IList<GetAllWorkoutsQueryResponse>>>
    {
    }
}
