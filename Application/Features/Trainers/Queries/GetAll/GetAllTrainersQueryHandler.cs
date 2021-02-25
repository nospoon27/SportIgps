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
using System.Transactions;

namespace Application.Features.Trainers.Queries.GetAll
{
    public class GetAllTrainersQueryHandler : CommonHandler, IRequestHandler<GetAllTrainersQuery, Response<IList<TrainerDTO>>>
    {
        public GetAllTrainersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<TrainerDTO>>> Handle(GetAllTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = await _unitOfWork.GetRepository<Trainer>().GetAllAsync(include: s => s.Include(x => x.User));

            var result = _mapper.Map<IList<TrainerDTO>>(trainers);
            return new Response<IList<TrainerDTO>>(result);
        }
    }
}
