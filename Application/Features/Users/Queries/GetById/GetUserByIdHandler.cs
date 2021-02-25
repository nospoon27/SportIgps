using Application.Features.DTOs;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Response<UserDTO>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<Response<UserDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.FindById(request.Id);
            if (user == null) throw new KeyNotFoundException($"Пользователь с ключом {request.Id} не найден");
            var response = new Response<UserDTO>(_mapper.Map<UserDTO>(user));
            return response;
        }
    }
}
