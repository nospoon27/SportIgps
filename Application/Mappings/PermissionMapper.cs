using Application.Features.Permissions.Commands.UpdatePermission;
using Application.Features.Permissions.Queries.GetAll;
using Application.Features.Permissions.Queries.GetCurrentUserPermissions;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class PermissionMapper : Profile
    {
        public PermissionMapper()
        {
            CreateMap<RoleClaim, GetAllPermissionsResponse>()
                .ForMember(x => x.Value, o => o.MapFrom(rc => rc.ClaimValue))
                .ForMember(x => x.Id, o => o.MapFrom(rc => rc.Id))
                .ForMember(x => x.RoleName, o => o.MapFrom(rc => rc.Role.Name));

            CreateMap<RoleClaim, GetCurrentUserPermissionsResponse>()
                .ForMember(x => x.Value, o => o.MapFrom(rc => rc.ClaimValue))
                .ForMember(x => x.Id, o => o.MapFrom(rc => rc.Id))
                .ForMember(x => x.RoleName, o => o.MapFrom(rc => rc.Role.Name));
        }
    }
}
