using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AbonementLimits.Queries.GetById
{
    public class GetByIdAbonementLimitQuery : IRequest<Response<GetByIdAbonementLimitResponse>>
    {
        public int Id { get; set; }
    }
}
