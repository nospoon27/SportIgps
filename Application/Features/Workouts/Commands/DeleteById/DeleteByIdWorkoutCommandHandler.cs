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

namespace Application.Features.Workouts.Commands.DeleteById
{
    public class DeleteByIdWorkoutCommandHandler : CommonHandler, IRequestHandler<DeleteByIdWorkoutCommand, Response<int>>
    {
        public DeleteByIdWorkoutCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(DeleteByIdWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = (await _unitOfWork.GetRepository<Workout>().FindAsync(request.Id)) ?? throw new NotFoundException(nameof(Workout), request.Id);
            _unitOfWork.GetRepository<Workout>().Delete(workout);

            return new Response<int>(request.Id);
        }
    }
}
