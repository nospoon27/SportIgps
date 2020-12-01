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

namespace Application.Features.Sports.Commands.Create
{
    public class CreateSportCommandHandler : IRequestHandler<CreateSportCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateSportCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSportCommand request, CancellationToken cancellationToken)
        {
            var sport = _mapper.Map<Sport>(request);
            await _unitOfWork.GetRepository<Sport>().InsertAsync(sport);
            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(sport.Id);
        }
    }
}
