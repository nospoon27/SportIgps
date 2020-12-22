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

namespace Application.Features.AbonementLimits.Commands.Create
{
    public class CreateAbonementLimitCommandHandler : CommonHandler, IRequestHandler<CreateAbonementLimitCommand, Response<int>>
    {
        public CreateAbonementLimitCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(CreateAbonementLimitCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<AbonementLimit>(request);
            await _unitOfWork.GetRepository<AbonementLimit>().InsertAsync(item);
            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(item.Id);
        }
    }
}
