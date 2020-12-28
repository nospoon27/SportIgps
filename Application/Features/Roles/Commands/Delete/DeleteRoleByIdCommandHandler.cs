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

namespace Application.Features.Roles.Commands.Delete
{
    public class DeleteRoleByIdCommandHandler : CommonHandler, IRequestHandler<DeleteRoleByIdCommand, Response<int>>
    {
        public DeleteRoleByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(DeleteRoleByIdCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<Role>().FindAsync(request.Id);
            if (item == null) throw new NotFoundException(nameof(Role), request.Id);

            _unitOfWork.GetRepository<Role>().Delete(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(item.Id);
        }
    }
}
