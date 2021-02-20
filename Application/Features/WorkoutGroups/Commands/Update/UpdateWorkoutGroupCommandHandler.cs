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

namespace Application.Features.WorkoutGroups.Commands.Update
{
    public class UpdateWorkoutGroupCommandHandler : CommonHandler, IRequestHandler<UpdateWorkoutGroupCommand, Response<int>>
    {
        public UpdateWorkoutGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(UpdateWorkoutGroupCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<WorkoutGroup>().FindAsync(request.Id);

            if (item == null) throw new NotFoundException("WorkoutGroup", request.Id);

            item.Name = request.Name;
            item.Description = request.Description;
            item.LocationId = request.LocationId;
            item.SportId = request.SportId;
            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(request.Id);
        }
    }
}
