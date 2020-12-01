﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Sports.Queries.GetAllPaged
{
    public class GetAllPagedSportsResponse : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
