using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.DeleteUserById
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<int>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetRepository<User>()
                .FindAsync(request.Id);

            if (user == null) throw new KeyNotFoundException($"Пользователь с ключом {request.Id} не найден");

            _unitOfWork.GetRepository<User>()
                .Delete(request.Id);

            return new Response<int>(request.Id);
        }
    }
}
