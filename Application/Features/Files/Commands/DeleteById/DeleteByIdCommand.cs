using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Commands.DeleteById
{
    public class DeleteByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
