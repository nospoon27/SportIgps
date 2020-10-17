using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Queris.GetAllPaged
{
    public class GetAllPagedLocationsResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PeopleAmount { get; set; }
    }
}
