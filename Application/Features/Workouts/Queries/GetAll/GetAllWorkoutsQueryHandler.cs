using Application.Features.Common;
using Application.Features.DTOs;
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

namespace Application.Features.Workouts.Queries.GetAll
{
    public class GetAllWorkoutsQueryHandler : CommonHandler, IRequestHandler<GetAllWorkoutsQuery, Response<IList<WorkoutDTO>>>
    {
        public GetAllWorkoutsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<WorkoutDTO>>> Handle(GetAllWorkoutsQuery request, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.GetRepository<Workout>().GetAllAsync();
            var mapped = _mapper.Map<IList<WorkoutDTO>>(items);

            return new Response<IList<WorkoutDTO>>(mapped);
        }
    }
}
