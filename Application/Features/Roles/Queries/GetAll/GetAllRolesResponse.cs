﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Roles.Queries.GetAll
{
    public class GetAllRolesResponse : BaseEntity
    {
        public string Name { get; set; }
    }
}
