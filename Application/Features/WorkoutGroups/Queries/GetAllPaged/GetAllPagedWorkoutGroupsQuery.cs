using Application.Parameters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutGroupsQuery : ISortRequest, IPagedRequest, IRequest<Response<IList<GetAllPagedWorkoutGroupsQueryResponse>>>
    {
        public string Sort { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
