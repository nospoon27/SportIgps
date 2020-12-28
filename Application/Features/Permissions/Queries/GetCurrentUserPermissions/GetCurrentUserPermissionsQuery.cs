using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Permissions.Queries.GetCurrentUserPermissions
{
    public class GetCurrentUserPermissionsQuery : IRequest<Response<IList<GetCurrentUserPermissionsResponse>>>
    {
    }
}
