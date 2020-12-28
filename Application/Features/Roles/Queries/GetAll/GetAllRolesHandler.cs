using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Roles.Queries.GetAll
{
    public class GetAllRolesHandler : CommonHandler, IRequestHandler<GetAllRolesQuery, Response<IList<GetAllRolesResponse>>>
    {
        public GetAllRolesHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<GetAllRolesResponse>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.GetRepository<Role>().GetAllAsync();

            return new Response<IList<GetAllRolesResponse>>(_mapper.Map<IList<GetAllRolesResponse>>(items));
        }
    }
}
