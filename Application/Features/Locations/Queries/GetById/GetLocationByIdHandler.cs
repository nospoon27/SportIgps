using Application.Features.DTOs;
using Application.Features.Users.Queries.GetById;
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

namespace Application.Features.Locations.Queris.GetById
{
    public class GetLocationByIdHandler : IRequestHandler<GetLocationByIdQuery, Response<LocationDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetLocationByIdHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<LocationDTO>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _unitOfWork.GetRepository<Location>().FindAsync(request.Id);
            if (location == null) throw new KeyNotFoundException($"Локация с ключом {request.Id} не найдена");
            var response = new Response<LocationDTO>(_mapper.Map<LocationDTO>(location));

            return response;
        }
    }
}
