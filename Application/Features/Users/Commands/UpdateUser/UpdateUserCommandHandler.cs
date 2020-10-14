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

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetRepository<User>()
                .FindAsync(request.Id);
            if (user == null) throw new KeyNotFoundException($"Пользователь с ключом {request.Id} не найден");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.MiddleName = request.MiddleName;
            user.PhoneNumber = request.PhoneNumber;
            user.DateOfBirth = request.DateOfBirth;
            user.GenderId = request.GenderId;

            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(user.Id);
        }
    }
}
