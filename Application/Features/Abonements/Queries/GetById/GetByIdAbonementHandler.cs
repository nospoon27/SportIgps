using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Abonements.Queries.GetById
{
    public class GetByIdAbonementHandler : CommonHandler, IRequestHandler<GetByIdAbonementQuery, Response<GetByIdAbonementResponse>>
    {
        public GetByIdAbonementHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<GetByIdAbonementResponse>> Handle(GetByIdAbonementQuery request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<Abonement>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.Id == request.Id,
                selector: x => _mapper.Map<GetByIdAbonementResponse>(x),
                include: s => s
                .Include(x => x.Workout)
                .Include(x => x.WorkoutGroup)
                .Include(x => x.AbonementLimit));
            return new Response<GetByIdAbonementResponse>(item);
        }
    }
}
