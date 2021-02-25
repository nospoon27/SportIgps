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

namespace Application.Features.WorkoutGroups.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutGroupsHandler : CommonHandler, IRequestHandler<GetAllPagedWorkoutGroupsQuery, Response<IList<WorkoutGroupDTO>>>
    {
        public GetAllPagedWorkoutGroupsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<WorkoutGroupDTO>>> Handle(GetAllPagedWorkoutGroupsQuery request, CancellationToken cancellationToken)
        {
            var items = (await _unitOfWork.GetRepository<WorkoutGroup>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<WorkoutGroupDTO>(s),
                include: s => s.Include(x => x.Location)
                .Include(x => x.Sport)
                .Include(x => x.WorkoutGroupTrainers)
                .ThenInclude(x => x.Trainer)
                .ThenInclude(x => x.User),
                sieve: request)).ToPagedResponse();

            return items;
        }
    }
}
