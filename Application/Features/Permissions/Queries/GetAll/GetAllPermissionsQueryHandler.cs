using Application.CustomTypes;
using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Permissions.Queries.GetAll
{
    public class GetAllPermissionsQueryHandler : CommonHandler, IRequestHandler<GetAllPermissionsQuery, Response<IList<GetAllPermissionsResponse>>>
    {
        public GetAllPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<GetAllPermissionsResponse>>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.GetRepository<RoleClaim>()
                .GetAllAsync(
                predicate: x => x.ClaimType == CustomClaimTypes.Permission && (request.RoleName != null ? x.Role.Name == request.RoleName : true),
                orderBy: x => x.OrderBy(o => o.Role.Name).ThenBy(x => x.ClaimValue),
                include: source => source.Include(x => x.Role));

            return new Response<IList<GetAllPermissionsResponse>>(_mapper.Map<IList<GetAllPermissionsResponse>>(result));
        }
    }
}
