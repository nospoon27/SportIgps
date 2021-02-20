using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ScheduleEvents.Queries.GetWorkoutGroup
{
    public class GetScheduleEventsByWorkoutGroupHandler : IRequestHandler<GetScheduleEventsByWorkoutGroupRequest, Response<IList<GetScheduleEventsByWorkoutGroupResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetScheduleEventsByWorkoutGroupHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IList<GetScheduleEventsByWorkoutGroupResponse>>> Handle(GetScheduleEventsByWorkoutGroupRequest request, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.GetRepository<ScheduleEvent>()
                .GetAllAsync(
                predicate: GetPredicate(request),
                orderBy: x => x.OrderBy(e => e.Start).ThenBy(e => e.End),
                include: x => x.Include(x => x.Trainers)
                    .ThenInclude(t => t.User)
                    .ThenInclude(u => u.UserPhoto));

            var result = _mapper.Map<IList<GetScheduleEventsByWorkoutGroupResponse>>(events);

            return new Response<IList<GetScheduleEventsByWorkoutGroupResponse>>(result);
        }

        private Expression<Func<ScheduleEvent, bool>> GetPredicate(GetScheduleEventsByWorkoutGroupRequest request)
        {
            return e =>
                e.WorkoutGroupId == request.WorkoutGroupId
                && e.Start >= request.Start
                && e.End <= request.End;
        }
    }
}
