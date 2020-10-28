using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Users.Queries.GetGenders
{
    public class GetGendersQuery : IRequest<Response<IList<GetGendersResponse>>>
    {
    }
}
