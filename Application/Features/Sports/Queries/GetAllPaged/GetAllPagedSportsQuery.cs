using Application.Parameters;
using Application.Sieve.Models;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Sports.Queries.GetAllPaged
{
    public class GetAllPagedSportsQuery : SieveModel, IRequest<PagedResponse<IList<GetAllPagedSportsResponse>>>
    {
    }
}
