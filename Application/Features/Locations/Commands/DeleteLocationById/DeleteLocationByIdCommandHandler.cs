using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Locations.Commands.DeleteLocationById
{
    public class DeleteLocationByIdCommandHandler : IRequestHandler<DeleteLocationByIdCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteLocationByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<int>> Handle(DeleteLocationByIdCommand request, CancellationToken cancellationToken)
        {
            var location = await _unitOfWork.GetRepository<Location>()
                .FindAsync(request.Id);

            if (location == null) throw new KeyNotFoundException($"Локация с ключом {request.Id} не найдена");

            _unitOfWork.GetRepository<Location>().Delete(location);
            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(request.Id);
        }
    }
}
