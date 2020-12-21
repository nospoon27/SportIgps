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

namespace Application.Features.Workouts.Commands.Create
{
    public class CreateWorkoutCommandHandler : CommonHandler, IRequestHandler<CreateWorkoutCommand, Response<int>>
    {
        public CreateWorkoutCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = _mapper.Map<Workout>(request);
            await _unitOfWork.GetRepository<Workout>().InsertAsync(workout);
            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(workout.Id);
        }
    }
}
