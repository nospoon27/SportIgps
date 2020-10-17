using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PeopleAmount { get; set; }
    }
}
