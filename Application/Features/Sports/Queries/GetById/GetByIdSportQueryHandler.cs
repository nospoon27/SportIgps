using Application.Exceptions;
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

namespace Application.Features.Sports.Queries.GetById
{
    public class GetByIdSportQueryHandler : CommonHandler, IRequestHandler<GetByIdSportQuery, Response<SportDTO>>
    {
        public GetByIdSportQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<SportDTO>> Handle(GetByIdSportQuery request, CancellationToken cancellationToken)
        {
            var sport = (await _unitOfWork.GetRepository<Sport>().FindAsync(request.Id)) ?? throw new NotFoundException(nameof(Sport), request.Id);

            return new Response<SportDTO>(_mapper.Map<SportDTO>(sport));
        }
    }
}
