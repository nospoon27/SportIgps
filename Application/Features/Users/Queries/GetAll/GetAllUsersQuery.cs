using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Users.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<Response<IList<GetAllUsersResponse>>>
    {
    }
}
