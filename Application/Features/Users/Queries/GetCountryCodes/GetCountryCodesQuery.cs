using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Users.Queries.GetCountryCodes
{
    public class GetCountryCodesQuery : IRequest<Response<IList<GetCountryCodesResponse>>>
    {
    }
}
