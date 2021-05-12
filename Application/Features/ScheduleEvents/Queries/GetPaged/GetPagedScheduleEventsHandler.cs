using Application.Extensions;
using Application.Features.Common;
using Application.Features.DTOs;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.crud.ScheduleEvents.Queries.GetPaged
{
    public class GetPagedScheduleEventsHandler : CommonHandler, IRequestHandler<GetPagedScheduleEventsQuery, Response<IList<ScheduleEventDTO>>>
    {
        public GetPagedScheduleEventsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<ScheduleEventDTO>>> Handle(GetPagedScheduleEventsQuery request, CancellationToken cancellationToken)
        {
            var result = (await _unitOfWork.GetRepository<ScheduleEvent>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<ScheduleEventDTO>(s),
                sieve: request)).ToPagedResponse();

            return result;
        }
    }
}
