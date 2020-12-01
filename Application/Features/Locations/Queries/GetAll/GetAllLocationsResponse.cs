using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Queries.GetAll
{
    public class GetAllLocationsResponse : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PeopleAmount { get; set; }
    }
}
