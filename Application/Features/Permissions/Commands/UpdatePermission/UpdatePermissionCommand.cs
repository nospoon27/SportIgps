using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string RoleName { get; set; }
    }
}
