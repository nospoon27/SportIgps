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

namespace Application.Features.Roles.Commands.Create
{
    public class CreateRoleCommandHandler : CommonHandler, IRequestHandler<CreateRoleCommand, Response<int>>
    {
        public CreateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Role>(request);
            var findByName = await _unitOfWork.GetRepository<Role>().GetSingleOrDefaultAsync(predicate: x => x.Name == request.Name);
            if (findByName != null) throw new ApiException("Роль с таким именем уже существует");

            await _unitOfWork.GetRepository<Role>().InsertAsync(item);
            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(item.Id);
        }
    }
}
