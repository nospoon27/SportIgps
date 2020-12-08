using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Sports.Queries.GetById
{
    public class GetByIdSportQuery : IRequest<Response<GetByIdSportQueryResponse>>
    {
        public int Id { get; set; }
    }
}
