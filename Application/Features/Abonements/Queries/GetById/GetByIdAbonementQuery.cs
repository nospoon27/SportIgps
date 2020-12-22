﻿using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abonements.Queries.GetById
{
    public class GetByIdAbonementQuery : IRequest<Response<GetByIdAbonementResponse>>
    {
        public int Id { get; set; }
    }
}
