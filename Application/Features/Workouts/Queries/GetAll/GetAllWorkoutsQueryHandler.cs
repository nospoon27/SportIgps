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

namespace Application.Features.Workouts.Queries.GetAll
{
    public class GetAllWorkoutsQueryHandler : CommonHandler, IRequestHandler<GetAllWorkoutsQuery, Response<IList<GetAllWorkoutsQueryResponse>>>
    {
        public GetAllWorkoutsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<GetAllWorkoutsQueryResponse>>> Handle(GetAllWorkoutsQuery request, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.GetRepository<Workout>().GetAllAsync();
            var mapped = _mapper.Map<IList<GetAllWorkoutsQueryResponse>>(items);

            return new Response<IList<GetAllWorkoutsQueryResponse>>(mapped);
        }
    }
}
