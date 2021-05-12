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
using Microsoft.EntityFrameworkCore;
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
                .GetFirstOrDefaultAsync(
                predicate: x => x.Id == request.WorkoutGroupId,
                include: source => source.Include(x => x.WorkoutGroupTrainers).ThenInclude(x => x.Trainer));

            if (location == null) throw new NotFoundException("Локация не найдена.");
            if (workoutGroup == null) throw new NotFoundException("Занятие не найдено.");

            var newEvent = _mapper.Map<ScheduleEvent>(request);

            // Проверка на изменение состава тренеров и внесение в таблицу ScheduleEventTrainers
            var intersectingTrainerIds = workoutGroup.WorkoutGroupTrainers.Select(x => x.TrainerId).Intersect(request.Trainers);
            if (intersectingTrainerIds.Count() == request.Trainers.Count)
            {
                newEvent.TrainerMembershipIsChanged = false;

                newEvent.ScheduleEventTrainers = workoutGroup.WorkoutGroupTrainers.Select(workoutGroupTrainer =>
                        new ScheduleEventTrainer
                        {
                            TrainerId = workoutGroupTrainer.Trainer.Id,
                            ScheduleEventId = newEvent.Id
                        }).ToList();
            }
            else
            {
                newEvent.TrainerMembershipIsChanged = true;
                var trainers = await _unitOfWork.GetRepository<Trainer>().GetAllAsync(predicate: x => request.Trainers.Contains(x.Id));

                newEvent.ScheduleEventTrainers = trainers.Select(trainer => new ScheduleEventTrainer
                {
                    TrainerId = trainer.Id,
                    ScheduleEventId = newEvent.Id
                }).ToList();
            }

            await _unitOfWork.GetRepository<ScheduleEvent>().InsertAsync(newEvent);

            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(newEvent.Id);
        }
    }
}
