﻿using Application.Interfaces.Services;
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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
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
        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.FindById(request.Id);
            if (user == null) throw new KeyNotFoundException($"Пользователь с ключом {request.Id} не найден");
            var response = new Response<GetUserByIdResponse>(_mapper.Map<GetUserByIdResponse>(user));
            return response;
        }
    }
}
