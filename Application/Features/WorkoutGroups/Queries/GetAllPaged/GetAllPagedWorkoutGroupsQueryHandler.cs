using Application.Extensions;
using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.UnitOfWork.Sorting;
using Application.Parameters;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkoutGroups.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutGroupsQueryHandler : CommonHandler, IRequestHandler<GetAllPagedWorkoutGroupsQuery ,Response<IList<GetAllPagedWorkoutGroupsQueryResponse>>>
    {
        public GetAllPagedWorkoutGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<GetAllPagedWorkoutGroupsQueryResponse>>> Handle(GetAllPagedWorkoutGroupsQuery request, CancellationToken cancellationToken)
        {
            var filter = new PagedRequest(request.PageNumber, request.PageSize);
            var items = (await _unitOfWork.GetRepository<WorkoutGroup>()
                .GetPagedListAsync(
                selector: s => _mapper.Map<GetAllPagedWorkoutGroupsQueryResponse>(s),
                pageIndex: filter.PageNumber,
                orderBy: s => s.OrderBy(request.Sort),
                pageSize: filter.PageSize)).ToPagedResponse();

            return items;
        }
    }
}
