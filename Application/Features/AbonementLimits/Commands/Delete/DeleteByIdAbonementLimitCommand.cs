using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AbonementLimits.Commands.Delete
{
    public class DeleteByIdAbonementLimitCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
