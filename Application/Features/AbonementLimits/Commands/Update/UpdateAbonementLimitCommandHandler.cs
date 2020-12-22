using Application.Features.Common;
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

namespace Application.Features.AbonementLimits.Commands.Update
{
    public class UpdateAbonementLimitCommandHandler : CommonHandler, IRequestHandler<UpdateAbonementLimitCommand, Response<int>>
    {
        public UpdateAbonementLimitCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(UpdateAbonementLimitCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<AbonementLimit>().FindAsync(request.Id);

            item.VisitAmount = request.VisitAmount;
            item.StartTime = request.StartTime;
            item.EndTime = request.EndTime;

            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(request.Id);
        }
    }
}
