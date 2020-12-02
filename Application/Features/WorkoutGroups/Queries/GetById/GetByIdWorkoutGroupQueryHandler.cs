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

namespace Application.Features.WorkoutGroups.Queries.GetById
{
    public class GetByIdWorkoutGroupQueryHandler : CommonHandler, IRequestHandler<GetByIdWorkoutGroupQuery, Response<GetByIdWorkoutGroupQueryResponse>>
    {
        public GetByIdWorkoutGroupQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<GetByIdWorkoutGroupQueryResponse>> Handle(GetByIdWorkoutGroupQuery request, CancellationToken cancellationToken)
        {
            var item = (await _unitOfWork.GetRepository<WorkoutGroup>().FindAsync(request.Id)) ?? throw new NotFoundException(nameof(WorkoutGroup), request.Id);

            return new Response<GetByIdWorkoutGroupQueryResponse>(_mapper.Map<GetByIdWorkoutGroupQueryResponse>(item));
        }
    }
}
