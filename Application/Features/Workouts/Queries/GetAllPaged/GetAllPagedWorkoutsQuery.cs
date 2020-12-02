using Application.Parameters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Workouts.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutsQuery : ISortRequest, IPagedRequest, IRequest<Response<IList<GetAllPagedWorkoutsQueryResponse>>>
    {
        public string Sort { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
