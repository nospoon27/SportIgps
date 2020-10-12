using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class RoleClaim
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
