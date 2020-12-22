using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AbonementLimits.Commands.Create
{
    public class CreateAbonementLimitCommand : IRequest<Response<int>>
    {
        public int VisitAmount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
