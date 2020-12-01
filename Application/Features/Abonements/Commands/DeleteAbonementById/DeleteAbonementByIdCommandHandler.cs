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

namespace Application.Features.Abonements.Commands.DeleteAbonementById
{
    public class DeleteAbonementByIdCommandHandler : CommonHandler, IRequestHandler<DeleteAbonementByIdCommand, Response<int>>
    {
        public DeleteAbonementByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(DeleteAbonementByIdCommand request, CancellationToken cancellationToken)
        {
            var abonement = await _unitOfWork.GetRepository<Abonement>().GetSingleOrDefaultAsync(predicate: x => x.Id == request.Id);
            if (abonement == null) throw new NotFoundException("Абонемент", request.Id);

            _unitOfWork.GetRepository<Abonement>().Delete(request.Id);

            return new Response<int>(request.Id);
        }
    }
}
