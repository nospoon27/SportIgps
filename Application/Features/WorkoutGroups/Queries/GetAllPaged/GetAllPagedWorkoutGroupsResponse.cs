﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkoutGroups.Queries.GetAllPaged
{
    public class GetAllPagedWorkoutGroupsResponse : BaseEntity
    {
        public string Name { get; set; }
    }
}