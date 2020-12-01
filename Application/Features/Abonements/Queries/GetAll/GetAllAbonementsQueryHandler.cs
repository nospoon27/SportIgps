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

namespace Application.Features.Abonements.Queries.GetAll
{
    public class GetAllAbonementsQueryHandler : CommonHandler, IRequestHandler<GetAllAbonementsQuery, Response<IList<GetAllAbonementsQueryResponse>>>
    {
        public GetAllAbonementsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<GetAllAbonementsQueryResponse>>> Handle(GetAllAbonementsQuery request, CancellationToken cancellationToken)
        {
            var abonements = await _unitOfWork.GetRepository<Abonement>().GetAllAsync(
                include: source => source.Include(x => x.Workout).Include(x => x.AbonementLimit));

            return new Response<IList<GetAllAbonementsQueryResponse>>(_mapper.Map<IList<GetAllAbonementsQueryResponse>>(abonements));
        }
    }
}
