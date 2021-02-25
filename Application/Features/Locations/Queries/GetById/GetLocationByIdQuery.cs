using Application.Features.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Queris.GetById
{
    public class GetLocationByIdQuery : IRequest<Response<LocationDTO>>
    {
        public int Id { get; set; }
    }
}
