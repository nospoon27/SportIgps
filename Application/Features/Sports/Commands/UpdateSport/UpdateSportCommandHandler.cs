using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Sports.Commands.UpdateSport
{
    public class UpdateSportCommandHandler : IRequestHandler<UpdateSportCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateSportCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<int>> Handle(UpdateSportCommand request, CancellationToken cancellationToken)
        {
            var sport = await _unitOfWork.GetRepository<Sport>().FindAsync(request.Id);
            if (sport == null) throw new NotFoundException("Sport", request.Id);

            sport.Name = request.Name;
            sport.Description = request.Description;

            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(sport.Id);
        }
    }
}
