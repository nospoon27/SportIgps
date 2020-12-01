using Application.Features.Common;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Permissions.Queries.GetAll
{
    public class GetAllPermissionsQuery : IRequest<Response<IList<GetAllPermissionsResponse>>>
    {
        
    }
}
