using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Application.CustomTypes;

namespace Application.Features.Permissions.Queries.GetCurrentUserPermissions
{
    public class GetCurrentUserPermissionsHandler : IRequestHandler<GetCurrentUserPermissionsQuery, Response<IList<string>>>
    {
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IUnitOfWork _unitOfWork;
        public GetCurrentUserPermissionsHandler(
            IAuthenticatedUserService authenticatedUserService,
            IUnitOfWork unitOfWork)
        {
            _authenticatedUserService = authenticatedUserService;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<IList<string>>> Handle(GetCurrentUserPermissionsQuery request, CancellationToken cancellationToken)
        {
            var userId = _authenticatedUserService.UserId.Value;

            var user = await _unitOfWork.GetRepository<User>()
                .GetFirstOrDefaultAsync(
                predicate: x => x.Id == userId,
                include: source => source
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RoleClaims));

            var permissions = user.UserRoles
                .SelectMany(ur => ur.Role.RoleClaims?.Where(rc => rc.ClaimType == CustomClaimTypes.Permission)
                .Select(rc => rc.ClaimValue));

            return new Response<IList<string>>(permissions.ToList());
        }
    }
}
