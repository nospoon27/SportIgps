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
using AutoMapper;

namespace Application.Features.Permissions.Queries.GetCurrentUserPermissions
{
    public class GetCurrentUserPermissionsHandler : IRequestHandler<GetCurrentUserPermissionsQuery, Response<IList<GetCurrentUserPermissionsResponse>>>
    {
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCurrentUserPermissionsHandler(
            IAuthenticatedUserService authenticatedUserService,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _authenticatedUserService = authenticatedUserService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IList<GetCurrentUserPermissionsResponse>>> Handle(GetCurrentUserPermissionsQuery request, CancellationToken cancellationToken)
        {
            var userId = _authenticatedUserService.UserId.Value;

            var user = await _unitOfWork.GetRepository<User>()
                .GetFirstOrDefaultAsync(
                predicate: x => x.Id == userId,
                include: source => source
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RoleClaims));

            var claims = user.UserRoles
                .SelectMany(ur => ur.Role.RoleClaims?.Where(rc => rc.ClaimType == CustomClaimTypes.Permission))
                .OrderBy(x => x.Role.Name).ThenBy(x => x.ClaimValue)
                .ToList();

            return new Response<IList<GetCurrentUserPermissionsResponse>>(_mapper.Map<IList<GetCurrentUserPermissionsResponse>>(claims));
        }
        //public async Task<Response<IList<string>>> Handle(GetCurrentUserPermissionsQuery request, CancellationToken cancellationToken)
        //{
        //    var userId = _authenticatedUserService.UserId.Value;

        //    var user = await _unitOfWork.GetRepository<User>()
        //        .GetFirstOrDefaultAsync(
        //        predicate: x => x.Id == userId,
        //        include: source => source
        //        .Include(u => u.UserRoles)
        //        .ThenInclude(ur => ur.Role)
        //        .ThenInclude(r => r.RoleClaims));

        //    var permissions = user.UserRoles
        //        .SelectMany(ur => ur.Role.RoleClaims?.Where(rc => rc.ClaimType == CustomClaimTypes.Permission)
        //        .Select(rc => rc.ClaimValue));

        //    return new Response<IList<string>>(permissions.ToList());
        //}
    }
}
