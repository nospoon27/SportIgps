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

namespace Application.Features.WorkoutGroups.Queries.GetAll
{
    public class GetAllWorkoutGroupsQueryHandler : CommonHandler, IRequestHandler<GetAllWorkoutGroupsQuery, Response<IList<GetAllWorkoutGroupsQueryResponse>>>
    {
        public GetAllWorkoutGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<GetAllWorkoutGroupsQueryResponse>>> Handle(GetAllWorkoutGroupsQuery request, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.GetRepository<WorkoutGroup>()
                .GetAllAsync();
            var mapped = _mapper.Map<IList<GetAllWorkoutGroupsQueryResponse>>(items);

            return new Response<IList<GetAllWorkoutGroupsQueryResponse>>(mapped);
        }
    }
}
