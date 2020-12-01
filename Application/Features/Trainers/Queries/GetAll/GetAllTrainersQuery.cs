using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Trainers.Queries.GetAll
{
    public class GetAllTrainersQuery : IRequest<Response<IList<GetAllTrainersQueryResponse>>>
    {
    }
}
