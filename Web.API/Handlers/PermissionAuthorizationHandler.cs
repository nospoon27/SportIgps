using Application.CustomTypes;
using Application.Exceptions;
using Application.Interfaces.Services;
using Infrastructure.Persistence.Identity.AccessControl;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Handlers
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IUserService _userService;
        public PermissionAuthorizationHandler(
            IAuthenticatedUserService authenticatedUserService,
            IUserService userService)
        {
            _authenticatedUserService = authenticatedUserService;
            _userService = userService;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null) return;

            var currentUserId = _authenticatedUserService.UserId ?? throw new UnauthorizedException("Вы не авторизованы");

            var user = await _userService.FindByIdWithRoleClaims(currentUserId);
            var userRoles = user.UserRoles;
            foreach(var ur in userRoles)
            {
                var permissions = ur.Role.RoleClaims
                    .Where(c => c.ClaimType == CustomClaimTypes.Permission
                           && (c.ClaimValue == requirement.Permission || c.ClaimValue == "*"));
                if (permissions.Any())
                {
                    context.Succeed(requirement);
                    return;
                }
            }
        }
    }
}
