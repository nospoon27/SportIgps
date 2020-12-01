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

namespace Application.Features.Trainers.Commands.Update
{
    public class UpdateTrainerCommandHandler : CommonHandler, IRequestHandler<UpdateTrainerCommand, Response<int>>
    {
        public UpdateTrainerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(UpdateTrainerCommand request, CancellationToken cancellationToken)
        {
            var trainer = await _unitOfWork.GetRepository<Trainer>().FindAsync(request.Id);

            if (trainer == null) throw new NotFoundException("Trainer", request.Id);

            trainer.CanBePersonal = request.CanBePersonal;
            trainer.UserId = request.UserId;

            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(request.Id);
        }
    }
}
