using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Roles.Commands.Delete
{
    public class DeleteRoleByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
