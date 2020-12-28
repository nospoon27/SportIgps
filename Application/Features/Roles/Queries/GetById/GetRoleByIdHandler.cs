using Application.Exceptions;
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

namespace Application.Features.Roles.Queries.GetById
{
    public class GetRoleByIdHandler : CommonHandler, IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResponse>>
    {
        public GetRoleByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<GetRoleByIdResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<Role>().FindAsync(request.Id) 
                ?? throw new NotFoundException(nameof(Role), request.Id);

            return new Response<GetRoleByIdResponse>(_mapper.Map<GetRoleByIdResponse>(item));
        }
    }
}
