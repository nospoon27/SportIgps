using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Queris.GetAllPaged
{
    public class GetAllPagedLocationsQuery : IRequest<PagedResponse<IList<GetAllPagedLocationsResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
