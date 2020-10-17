using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Queris.GetById
{
    public class GetLocationByIdQuery : IRequest<Response<GetLocationByIdResponse>>
    {
        public int Id { get; set; }
    }
}
