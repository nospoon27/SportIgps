﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class LocationDTO : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PeopleAmount { get; set; }
    }
}
