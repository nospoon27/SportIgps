using Application.Interfaces.UnitOfWork;
using Application.Parameters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Users.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<PagedResponse<IList<GetAllUsersResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
