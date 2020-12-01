using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Queries.GetAll
{
    public class GetAllLocationsQuery : IRequest<Response<IList<GetAllLocationsResponse>>>
    {
    }
}
