using Application.Exceptions;
using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Workouts.Commands.Update
{
    public class UpdateWorkoutCommandHandler : CommonHandler, IRequestHandler<UpdateWorkoutCommand, Response<int>>
    {
        public UpdateWorkoutCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = (await _unitOfWork.GetRepository<Workout>().FindAsync(request.Id)) ?? throw new NotFoundException(nameof(Workout), request.Id);

            workout.Description = request.Description;
            workout.LocationId = request.LocationId;
            workout.Name = request.Name;
            workout.SportId = request.SportId;
            workout.TrainerId = request.TrainerId;

            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(workout.Id);
        }
    }
}
