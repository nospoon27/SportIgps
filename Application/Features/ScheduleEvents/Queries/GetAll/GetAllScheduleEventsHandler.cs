using Application.Features.Common;
using Application.Features.DTOs;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.crud.ScheduleEvents.Queries.GetAll
{
    public class GetAllScheduleEventsHandler : CommonHandler, IRequestHandler<GetAllScheduleEventsQuery, Response<IList<ScheduleEventDTO>>>
    {
        public GetAllScheduleEventsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<ScheduleEventDTO>>> Handle(GetAllScheduleEventsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.GetRepository<ScheduleEvent>()
                .GetAllAsync(include: source => source.Include(x => x.WorkoutGroup)
                                                      .Include(x => x.ScheduleEventTrainers)
                                                      .ThenInclude(x => x.Trainer));

            return new Response<IList<ScheduleEventDTO>>(_mapper.Map<IList<ScheduleEventDTO>>(result));
        }
    }
}
