using Application.Features.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Sports.Queries.GetAll
{
    public class GetAllSportsQuery : IRequest<Response<IList<SportDTO>>>
    {
    }
}
