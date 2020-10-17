using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PeopleAmount { get; set; }
    }
}
