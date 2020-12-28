using Application.Features.Roles.Commands.Create;
using Application.Features.Roles.Queries.GetAll;
using Application.Features.Roles.Queries.GetById;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class RoleMapper : GeneralProfile
    {
        public RoleMapper()
        {
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<Role, GetAllRolesResponse>();
            CreateMap<Role, GetRoleByIdResponse>();
        }
    }
}
