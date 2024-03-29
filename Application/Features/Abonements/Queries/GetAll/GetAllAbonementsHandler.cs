﻿using Application.Features.Common;
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

namespace Application.Features.Abonements.Queries.GetAll
{
    public class GetAllAbonementsHandler : CommonHandler, IRequestHandler<GetAllAbonementsQuery, Response<IList<AbonementDTO>>>
    {
        public GetAllAbonementsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<AbonementDTO>>> Handle(GetAllAbonementsQuery request, CancellationToken cancellationToken)
        {
            var abonements = await _unitOfWork.GetRepository<Abonement>().GetAllAsync(
                include: source => source.Include(x => x.Workout)
                .Include(x => x.AbonementLimit)
                .Include(x => x.WorkoutGroup));

            return new Response<IList<AbonementDTO>>(_mapper.Map<IList<AbonementDTO>>(abonements));
        }
    }
}
