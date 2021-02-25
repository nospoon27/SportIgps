using Application.Extensions;
using Application.Features.Common;
using Application.Features.DTOs;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.UnitOfWork.Sorting;
using Application.Parameters;
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

namespace Application.Features.Workouts.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutsHandler : CommonHandler, IRequestHandler<GetAllPagedWorkoutsQuery, Response<IList<WorkoutDTO>>>
    {
        public GetAllPagedWorkoutsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<WorkoutDTO>>> Handle(GetAllPagedWorkoutsQuery request, CancellationToken cancellationToken)
        {
            var items = (await _unitOfWork.GetRepository<Workout>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<WorkoutDTO>(s),
                sieve: request,
                include: s => s.Include(x => x.Location)
                               .Include(x => x.Sport))
                ).ToPagedResponse();

            return items;
        }
    }
}
