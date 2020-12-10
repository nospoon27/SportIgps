using Application.Parameters;
using Application.Sieve.Models;
using Application.Wrappers;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Trainers.Queries.GetAllPaged
{
    public class GetAllPagedTrainersQuery : SieveModel, IRequest<PagedResponse<IList<GetAllPagedTrainersResponse>>>
    {
    }
}
