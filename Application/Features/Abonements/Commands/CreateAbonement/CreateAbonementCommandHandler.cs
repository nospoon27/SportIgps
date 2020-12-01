using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Abonements.Commands.CreateAbonement
{
    public class CreateAbonementCommandHandler : CommonHandler ,IRequestHandler<CreateAbonementCommand, Response<int>>
    {
        public CreateAbonementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(CreateAbonementCommand request, CancellationToken cancellationToken)
        {
            var abonement = _mapper.Map<Abonement>(request);
            await _unitOfWork.GetRepository<Abonement>().InsertAsync(abonement);
            await _unitOfWork.SaveChangesAsync();

            return new Response<int>(abonement.Id);
        }
    }
}
