using Application.CustomTypes;
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

            var user = await _userService.FindByIdWithRoleClaims(_authenticatedUserService.UserId.Value);
            //var permissions = user.Roles.Select(r => r.RoleClaims
            //    .Select(c => c).Where(c => c.ClaimType == CustomClaimTypes.Permission 
            //                            && c.ClaimValue == requirement.Permission));
            var permissions = user.UserRoles.SelectMany(r => r.Role.RoleClaims)
                .Select(c => c).Where(c => c.ClaimType == CustomClaimTypes.Permission
                                        && c.ClaimValue == requirement.Permission);
            if (permissions.Any())
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}
