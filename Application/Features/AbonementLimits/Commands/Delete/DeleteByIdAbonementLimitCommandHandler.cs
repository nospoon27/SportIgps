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

namespace Application.Features.AbonementLimits.Commands.Delete
{
    public class DeleteByIdAbonementLimitCommandHandler : CommonHandler, IRequestHandler<DeleteByIdAbonementLimitCommand, Response<int>>
    {
        public DeleteByIdAbonementLimitCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(DeleteByIdAbonementLimitCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.GetRepository<AbonementLimit>().FindAsync(request.Id) ?? throw new NotFoundException(nameof(AbonementLimit), request.Id);
            _unitOfWork.GetRepository<AbonementLimit>().Delete(item.Id);

            return new Response<int>(request.Id);
        }
    }
}
