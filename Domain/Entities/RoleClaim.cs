﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class RoleClaim
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public RoleClaim() {}
        public RoleClaim(int roleId, string type, string value)
        {
            RoleId = roleId;
            ClaimType = type;
            ClaimValue = value;
        }
    }
}
