using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Trainers.Commands.Create
{
    public class CreateTrainerCommandHandler : CommonHandler, IRequestHandler<CreateTrainerCommand, Response<int>>
    {
        public CreateTrainerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(CreateTrainerCommand request, CancellationToken cancellationToken)
        {
            var trainer = _mapper.Map<Trainer>(request);
            await _unitOfWork.GetRepository<Trainer>().InsertAsync(trainer);
            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(trainer.Id);
        }
    }
}
