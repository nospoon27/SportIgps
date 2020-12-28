using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Roles.Commands.Create
{
    public class CreateRoleCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
}
