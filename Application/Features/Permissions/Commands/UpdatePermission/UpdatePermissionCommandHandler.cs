using Application.Features.Common;
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

namespace Application.Features.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommandHandler : CommonHandler, IRequestHandler<UpdatePermissionCommand, Response<int>>
    {
        public UpdatePermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _unitOfWork.GetRepository<RoleClaim>()
                .GetSingleOrDefaultAsync(predicate: x => x.Id == request.Id);
            var role = await _unitOfWork.GetRepository<Role>().GetSingleOrDefaultAsync(predicate: r => r.Name == request.RoleName);

            if (permission == null) new KeyNotFoundException($"Permission с ключом {request.Id} не найден");

            permission.ClaimValue = request.Value;
            permission.RoleId = role.Id;

            await _unitOfWork.SaveChangesAsync();
            
            return new Response<int>(request.Id);
        }
    }
}
