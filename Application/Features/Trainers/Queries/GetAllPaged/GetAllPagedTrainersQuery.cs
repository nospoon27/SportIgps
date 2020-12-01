using Application.Parameters;
using Application.Wrappers;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Trainers.Queries.GetAllPaged
{
    public class GetAllPagedTrainersQuery : ISortRequest, IPagedRequest, IRequest<PagedResponse<IList<GetAllPagedTrainersQueryResponse>>>
    {
        public string Sort { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
