using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Permissions.Commands.AddPermission
{
    public class AddPermissionCommand : IRequest<Response<int>>
    {
        public string Value { get; set; }
        public string RoleName { get; set; }
    }
}
