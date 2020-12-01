using Application.Exceptions;
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

namespace Application.Features.Abonements.Commands.UpdateAbonement
{
    public class UpdateAbonementCommandHandler : CommonHandler, IRequestHandler<UpdateAbonementCommand, Response<int>>
    {
        public UpdateAbonementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(UpdateAbonementCommand request, CancellationToken cancellationToken)
        {
            Abonement abonement = await _unitOfWork.GetRepository<Abonement>().GetSingleOrDefaultAsync(predicate: x => x.Id == request.Id);

            if (abonement == null) throw new NotFoundException("Абонемент", request.Id);

            abonement.IsChild = request.IsChild;
            abonement.Price = request.Price;
            abonement.WorkoutId = request.WorkoutId;
            abonement.AbonementLimitId = request.AbonementLimitId;

            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(abonement.Id);
        }
    }
}
