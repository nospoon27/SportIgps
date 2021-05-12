using Application.Features.DTOs;
using Application.Sieve.Models;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Abonements.Queries.GetAllPaged
{
    public class GetAllPagedAbonementsQuery : SieveModel, IRequest<Response<IList<AbonementDTO>>>
    {
    }
}
