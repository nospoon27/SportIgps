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
using Microsoft.EntityFrameworkCore;
using Application.Features.DTOs;

namespace Application.Features.WorkoutGroups.Queries.GetById
{
    public class GetByIdWorkoutGroupQueryHandler : CommonHandler, IRequestHandler<GetByIdWorkoutGroupQuery, Response<WorkoutGroupDTO>>
    {
        public GetByIdWorkoutGroupQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<WorkoutGroupDTO>> Handle(GetByIdWorkoutGroupQuery request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<WorkoutGroup>()
                .GetSingleOrDefaultAsync(
                include: s => s.Include(x => x.Location)
                .Include(x => x.Sport)
                .Include(x => x.WorkoutGroupTrainers)
                .ThenInclude(x => x.Trainer)
                .ThenInclude(x => x.User),
                predicate: x => x.Id == request.Id);
            if (item == null) throw new NotFoundException(nameof(WorkoutGroup), request.Id);

            return new Response<WorkoutGroupDTO>(_mapper.Map<WorkoutGroupDTO>(item));
        }
    }
}
