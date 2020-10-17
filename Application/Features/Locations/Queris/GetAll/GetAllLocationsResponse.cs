using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Queris.GetAll
{
    public class GetAllLocationsResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PeopleAmount { get; set; }
    }
}
