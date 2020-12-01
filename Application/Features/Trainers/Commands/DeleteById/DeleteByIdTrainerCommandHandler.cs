using Application.Exceptions;
using Application.Features.Common;
using Application.Features.Sports.Commands.DeleteSportById;
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

namespace Application.Features.Trainers.Commands.DeleteById
{
    public class DeleteByIdTrainerCommandHandler : CommonHandler, IRequestHandler<DeleteSportByIdCommand, Response<int>>
    {
        public DeleteByIdTrainerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(DeleteSportByIdCommand request, CancellationToken cancellationToken)
        {
            var trainer = await _unitOfWork.GetRepository<Trainer>().GetSingleOrDefaultAsync(predicate: x => x.Id == request.Id);
            if (trainer == null) throw new NotFoundException("Тренер", request.Id);

            _unitOfWork.GetRepository<Trainer>().Delete(trainer);
            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(request.Id);
        }
    }
}
