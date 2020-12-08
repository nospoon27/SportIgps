using Application.Interfaces.UnitOfWork;
using Application.Parameters;
using Application.Sieve.Models;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Users.Queries.GetAllPaged
{
    public class GetAllPagedUsersQuery : SieveModel, IRequest<PagedResponse<IList<GetAllPagedUsersResponse>>>
    {
    }
}
