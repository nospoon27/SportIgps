using Application.Features.DTOs;
using Application.Sieve.Models;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PersonalTrainings.Queries.GetPaged
{
    public class GetPagedPersonalTrainingsQuery : SieveModel, IRequest<PagedResponse<IList<PersonalTrainingDTO>>>
    {
    }
}
