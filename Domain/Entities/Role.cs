using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<UserRole> UserRoles { get; set; }
        [JsonIgnore]
        public ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
