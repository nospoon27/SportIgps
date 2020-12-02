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

namespace Application.Features.WorkoutGroups.Commands.Create
{
    public class CreateWorkoutGroupCommandHandler : CommonHandler, IRequestHandler<CreateWorkoutGroupCommand, Response<int>>
    {
        public CreateWorkoutGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(CreateWorkoutGroupCommand request, CancellationToken cancellationToken)
        {
            var workoutGroup = _mapper.Map<WorkoutGroup>(request);
            await _unitOfWork.GetRepository<WorkoutGroup>().InsertAsync(workoutGroup);
            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(workoutGroup.Id);
        }
    }
}
