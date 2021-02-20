using Application.Exceptions;
using Application.Features.Common;
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

namespace Application.Features.ScheduleEvents.Commands.Create
{
    public class CreateScheduleEventCommandHandler : CommonHandler, IRequestHandler<CreateScheduleEventCommand, Response<int>>
    {
        public CreateScheduleEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(CreateScheduleEventCommand request, CancellationToken cancellationToken)
        {
            var location = await _unitOfWork.GetRepository<Location>()
                .FindAsync(request.LocationId);
            var workoutGroup = await _unitOfWork.GetRepository<WorkoutGroup>()
                .FindAsync(request.WorkoutGroupId);

            if (location == null) throw new NotFoundException("Локация не найдена.");
            if (workoutGroup == null) throw new NotFoundException("Занятие не найдено.");

            var newEvent = _mapper.Map<ScheduleEvent>(request);
            await _unitOfWork.GetRepository<ScheduleEvent>().InsertAsync(newEvent);

            return new Response<int>(newEvent.Id);
        }
    }
}
