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
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;

namespace Application.Features.crud.ScheduleEvents.Commands.Update
{
    public class UpdateScheduleEventCommandHandler : CommonHandler, IRequestHandler<UpdateScheduleEventCommand, Response<int>>
    {
        public UpdateScheduleEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(UpdateScheduleEventCommand request, CancellationToken cancellationToken)
        {
            var item = (await _unitOfWork.GetRepository<ScheduleEvent>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.Id == request.Id,
                include: source => source.Include(x => x.ScheduleEventTrainers)
                                         .ThenInclude(x => x.Trainer))) 
                                         ?? throw new NotFoundException(nameof(ScheduleEvent), request.Id);

            var workoutGroup = await _unitOfWork.GetRepository<WorkoutGroup>()
                .GetFirstOrDefaultAsync(
                predicate: x => x.Id == request.WorkoutGroupId,
                include: source => source.Include(x => x.WorkoutGroupTrainers).ThenInclude(x => x.Trainer));

            var eventTrainers = await _unitOfWork.GetRepository<ScheduleEventTrainer>()
                .GetAllAsync(predicate: x => x.ScheduleEventId == request.Id);

            var intersectingTrainerIds = workoutGroup.WorkoutGroupTrainers.Select(x => x.TrainerId).Intersect(request.Trainers);
            if (intersectingTrainerIds.Count() == request.Trainers.Count)
            {
                item.TrainerMembershipIsChanged = false;
            }
            else
            {
                item.TrainerMembershipIsChanged = true;
            }

            var idsForDelete = eventTrainers.Select(x => x.TrainerId).Except(request.Trainers).ToList();
            var idsForInsert = request.Trainers.Except(eventTrainers.Select(x => x.TrainerId)).ToList();
            idsForDelete.ForEach(id => item.ScheduleEventTrainers.Remove(item.ScheduleEventTrainers.SingleOrDefault(x => x.TrainerId == id)));
            idsForInsert.ForEach(id => item.ScheduleEventTrainers.Add(new ScheduleEventTrainer
            {
                TrainerId = id,
                ScheduleEventId = item.Id
            }));

            item.LocationId = request.LocationId;
            item.WorkoutGroupId = request.WorkoutGroupId;
            item.Start = request.Start;
            item.End = request.End;

            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(request.Id);
        }
    }
}
