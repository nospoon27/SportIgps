using Application.Extensions;
using Application.Features.Common;
using Application.Features.DTOs;
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

namespace Application.Features.PersonalTrainings.Queries.GetPaged
{
    public class GetPagedPersonalTrainingsHandler : CommonHandler, IRequestHandler<GetPagedPersonalTrainingsQuery, PagedResponse<IList<PersonalTrainingDTO>>>
    {
        public GetPagedPersonalTrainingsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<PagedResponse<IList<PersonalTrainingDTO>>> Handle(GetPagedPersonalTrainingsQuery request, CancellationToken cancellationToken)
        {
            var personalTrainings = (await _unitOfWork.GetRepository<Location>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<PersonalTrainingDTO>(s),
                sieve: request)).ToPagedResponse();

            return personalTrainings;
        }
    }
}
