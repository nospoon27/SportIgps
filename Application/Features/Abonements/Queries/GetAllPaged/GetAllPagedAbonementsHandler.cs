using Application.Extensions;
using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Abonements.Queries.GetAllPaged
{
    public class GetAllPagedAbonementsHandler : CommonHandler, IRequestHandler<GetAllPagedAbonementsQuery, Response<IList<GetAllPagedAbonementsResponse>>>
    {
        public GetAllPagedAbonementsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<GetAllPagedAbonementsResponse>>> Handle(GetAllPagedAbonementsQuery request, CancellationToken cancellationToken)
        {
            var items = (await _unitOfWork.GetRepository<Abonement>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<GetAllPagedAbonementsResponse>(s),
                sieve: request,
                include: s => s.Include(x => x.AbonementLimit)
                               .Include(x => x.Workout)
                               .Include(x => x.WorkoutGroup))).ToPagedResponse();
            return items;
        }
    }
}
