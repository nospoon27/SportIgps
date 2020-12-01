using Application.Parameters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Sports.Queries.GetAllPaged
{
    public class GetAllPagedSportsQuery : ISortRequest, IPagedRequest, IRequest<PagedResponse<IList<GetAllPagedSportsResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
    }
}
