﻿using Application.Exceptions;
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

namespace Application.Features.Trainers.Queries.GetById
{
    public class GetByIdTrainerQueryHandler : CommonHandler, IRequestHandler<GetByIdTrainerQuery, Response<GetByIdTrainerQueryResponse>>
    {
        public GetByIdTrainerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<GetByIdTrainerQueryResponse>> Handle(GetByIdTrainerQuery request, CancellationToken cancellationToken)
        {
            var trainer = await _unitOfWork.GetRepository<Trainer>().GetSingleOrDefaultAsync(
                predicate: x => x.Id == request.Id, 
                include: s => s.Include(x => x.User));

            if (trainer == null) throw new NotFoundException("Тренер", request.Id);
            var result = _mapper.Map<GetByIdTrainerQueryResponse>(trainer);
            return new Response<GetByIdTrainerQueryResponse>(result);
        }
    }
}
