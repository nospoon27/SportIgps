using Application.Features.Common;
using Application.Features.DTOs;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;

namespace Application.Features.crud.ScheduleEvents.Queries.GetById
{
    public class GetByIdScheduleEventHandler : CommonHandler, IRequestHandler<GetByIdScheduleEventQuery, Response<ScheduleEventDTO>>
    {
        public GetByIdScheduleEventHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<ScheduleEventDTO>> Handle(GetByIdScheduleEventQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.GetRepository<ScheduleEvent>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.Id == request.Id,
                include: source => source.Include(x => x.WorkoutGroup)
                                         .Include(x => x.ScheduleEventTrainers)
                                         .ThenInclude(x => x.Trainer));

            if (result == null) throw new NotFoundException("SchdeuleEvent", result.Id);

            return new Response<ScheduleEventDTO>(_mapper.Map<ScheduleEventDTO>(result));
        }
    }
}
