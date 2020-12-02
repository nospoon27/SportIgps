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

namespace Application.Features.WorkoutGroups.Commands.DeleteById
{
    public class DeleteWorkoutGroupByIdCommandHandler : CommonHandler, IRequestHandler<DeleteWorkoutGroupByIdCommand, Response<int>>
    {
        public DeleteWorkoutGroupByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(DeleteWorkoutGroupByIdCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<WorkoutGroup>().FindAsync(request.Id);

            if (item == null) throw new NotFoundException("WorkoutGroup", request.Id);

            _unitOfWork.GetRepository<WorkoutGroup>().Delete(item);

            return new Response<int>(request.Id);
        }
    }
}
