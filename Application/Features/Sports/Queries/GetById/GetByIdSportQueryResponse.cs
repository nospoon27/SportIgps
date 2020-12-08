using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Sports.Queries.GetById
{
    public class GetByIdSportQueryResponse : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
