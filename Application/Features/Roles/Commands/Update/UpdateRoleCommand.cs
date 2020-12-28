using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Roles.Commands.Update
{
    public class UpdateRoleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
