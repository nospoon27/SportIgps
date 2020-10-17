using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateLocationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<int>> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _unitOfWork.GetRepository<Location>().FindAsync(request.Id);
            if (location == null) throw new KeyNotFoundException($"Локация с ключом {request.Id} не найдена");

            location.Description = request.Description;
            location.Name = request.Name;
            location.PeopleAmount = request.PeopleAmount;

            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(location.Id);
        }
    }
}
