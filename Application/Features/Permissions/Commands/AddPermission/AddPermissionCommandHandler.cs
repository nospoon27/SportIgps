using Application.CustomTypes;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Permissions.Commands.AddPermission
{
    public class AddPermissionCommandHandler : IRequestHandler<AddPermissionCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddPermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<int>> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.GetRepository<Role>()
                .GetSingleOrDefaultAsync(
                predicate:x => x.Name == request.RoleName);
            if (role == null) throw new ApiException($"Роль '{request.RoleName}' не найдена");

            var claimCheck = await _unitOfWork.GetRepository<RoleClaim>()
                .GetSingleOrDefaultAsync(
                predicate: x => x.RoleId == role.Id && x.ClaimValue == request.Value);
            if (claimCheck != null) throw new ApiException($"Уже существует permission {request.Value} для роли '{request.RoleName}'");

            RoleClaim rc = new RoleClaim(role.Id, CustomClaimTypes.Permission, request.Value);
            await _unitOfWork.GetRepository<RoleClaim>()
                .InsertAsync(rc);
            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(rc.Id);
        }
    }
}
