using Application.Exceptions;
using Application.Features.Common;
using Application.Features.DTOs;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Workouts.Queries.GetById
{
    public class GetByIdWorkoutQueryHandler : CommonHandler, IRequestHandler<GetByIdWorkoutQuery, Response<WorkoutDTO>>
    {
        public GetByIdWorkoutQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<WorkoutDTO>> Handle(GetByIdWorkoutQuery request, CancellationToken cancellationToken)
        {
            var workout = (await _unitOfWork.GetRepository<Workout>().GetSingleOrDefaultAsync(
                predicate: x => x.Id == request.Id,
                include: s => s.Include(x => x.Sport)
                .Include(x => x.Location)))
                ?? throw new NotFoundException(nameof(Workout), request.Id);

            return new Response<WorkoutDTO>(_mapper.Map<WorkoutDTO>(workout));
        }
    }
}
