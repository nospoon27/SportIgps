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

namespace Application.Features.PersonalTrainings.Commands.Create
{
    public class CreatePersonalTrainingHandler : CommonHandler, IRequestHandler<CreatePersonalTrainingCommand, Response<int>>
    {
        public CreatePersonalTrainingHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<int>> Handle(CreatePersonalTrainingCommand request, CancellationToken cancellationToken)
        {
            var newItem = _mapper.Map<PersonalTraining>(request);
            await _unitOfWork.GetRepository<PersonalTraining>().InsertAsync(newItem);

            await _unitOfWork.SaveChangesAsync();
            return new Response<int>(newItem.Id);
        }
    }
}
