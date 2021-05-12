using Application.Features.Common;
using Application.Features.DTOs;
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

namespace Application.Features.PersonalTrainings.Queries.GetAll
{
    public class GetAllPersonalTrainingsRequestHandler : CommonHandler, IRequestHandler<GetAllPersonalTrainingsRequest, Response<IList<PersonalTrainingDTO>>>
    {
        public GetAllPersonalTrainingsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<PersonalTrainingDTO>>> Handle(GetAllPersonalTrainingsRequest request, CancellationToken cancellationToken)
        {
            var personalTrainings = await _unitOfWork.GetRepository<PersonalTraining>()
                .GetAllAsync(
                include: source => source
                .Include(x => x.Trainer)
                .Include(x => x.Client)
                .Include(x => x.Sport));

            var mapped = _mapper.Map <IList<PersonalTrainingDTO>>(personalTrainings);
            return new Response<IList<PersonalTrainingDTO>>(mapped);
        }
    }
}
