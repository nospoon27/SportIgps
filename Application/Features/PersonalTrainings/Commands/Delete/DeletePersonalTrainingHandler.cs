using Application.Exceptions;
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

namespace Application.Features.PersonalTrainings.Commands.Delete
{
    public class DeletePersonalTrainingHandler : CommonHandler, IRequestHandler<DeletePersonalTrainingCommand, Response<int>>
    {
        public DeletePersonalTrainingHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(DeletePersonalTrainingCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<PersonalTraining>()
                .FindAsync(request.Id);
            if (item == null) throw new NotFoundException("Персональная тренировка", request.Id);
            _unitOfWork.GetRepository<PersonalTraining>().Delete(item);

            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(item.Id);
        }
    }
}
