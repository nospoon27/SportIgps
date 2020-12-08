using Application.Extensions;
using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.UnitOfWork.Sorting;
using Application.Parameters;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Workouts.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutsHandler : CommonHandler, IRequestHandler<GetAllPagedWorkoutsQuery, Response<IList<GetAllPagedWorkoutsResponse>>>
    {
        public GetAllPagedWorkoutsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<GetAllPagedWorkoutsResponse>>> Handle(GetAllPagedWorkoutsQuery request, CancellationToken cancellationToken)
        {
            var items = (await _unitOfWork.GetRepository<Workout>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<GetAllPagedWorkoutsResponse>(s),
                sieve: request)).ToPagedResponse();

            return items;
        }
    }
}
