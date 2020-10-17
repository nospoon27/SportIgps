using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Queris.GetAll
{
    public class GetAllLocationsQuery : IRequest<Response<IList<GetAllLocationsResponse>>>
    {
    }
}
