using Application.Features.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Sports.Queries.GetById
{
    public class GetByIdSportQuery : IRequest<Response<SportDTO>>
    {
        public int Id { get; set; }
    }
}
