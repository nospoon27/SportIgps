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

namespace Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateLocationCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = _mapper.Map<Location>(request);
            await _unitOfWork.GetRepository<Location>().InsertAsync(location);
            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(location.Id);
        }
    }
}
