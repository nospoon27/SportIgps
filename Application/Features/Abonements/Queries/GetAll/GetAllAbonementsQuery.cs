using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Abonements.Queries.GetAll
{
    public class GetAllAbonementsQuery : IRequest<Response<IList<GetAllAbonementsQueryResponse>>>
    {
    }
}
