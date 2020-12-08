using Application.Features.Locations.Queries.GetAllPaged;
using Application.Parameters;
using Application.Sieve.Models;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Queris.GetAllPaged
{
    public class GetAllPagedLocationsQuery : SieveModel, IRequest<PagedResponse<IList<GetAllPagedLocationsResponse>>>
    {
    }
}
