using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Sports.Commands.DeleteSportById
{
    public class DeleteSportByIdCommandHandler : IRequestHandler<DeleteSportByIdCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteSportByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<int>> Handle(DeleteSportByIdCommand request, CancellationToken cancellationToken)
        {
            var sport = await _unitOfWork.GetRepository<Sport>()
                .FindAsync(request.Id);

            if (sport == null) throw new NotFoundException("Sport", request.Id);

            _unitOfWork.GetRepository<Sport>().Delete(sport);
            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(request.Id);
        }
    }
}
