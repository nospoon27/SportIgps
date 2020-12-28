using Application.CustomTypes;
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

namespace Application.Features.Permissions.Commands.DeleteById
{
    public class DeletePermissionByIdCommandHandler : CommonHandler, IRequestHandler<DeletePermissionByIdCommand, Response<int>>
    {
        public DeletePermissionByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(DeletePermissionByIdCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<RoleClaim>()
                .GetSingleOrDefaultAsync(predicate: x =>
                    x.ClaimType == CustomClaimTypes.Permission
                    && x.Id == request.Id);
            _unitOfWork.GetRepository<RoleClaim>().Delete(item);
            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(item.Id);
        }
    }
}
