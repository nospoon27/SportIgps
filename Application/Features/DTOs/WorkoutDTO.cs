﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class WorkoutDTO : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationDTO Location { get; set; }
        public int LocationId { get; set; }
        public SportDTO Sport { get; set; }
        public int SportId { get; set; }
    }
}