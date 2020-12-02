using Application.Exceptions;
using Application.Features.Common;
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
    public class GetByIdWorkoutQueryHandler : CommonHandler, IRequestHandler<GetByIdWorkoutQuery, Response<GetByIdWorkoutQueryResponse>>
    {
        public GetByIdWorkoutQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<GetByIdWorkoutQueryResponse>> Handle(GetByIdWorkoutQuery request, CancellationToken cancellationToken)
        {
            var workout = (await _unitOfWork.GetRepository<Workout>().GetSingleOrDefaultAsync(
                predicate: x => x.Id == request.Id))
                ?? throw new NotFoundException(nameof(Workout), request.Id);

            return new Response<GetByIdWorkoutQueryResponse>(_mapper.Map<GetByIdWorkoutQueryResponse>(workout));
        }
    }
}
