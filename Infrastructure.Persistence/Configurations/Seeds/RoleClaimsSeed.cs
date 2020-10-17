using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations.Seeds
{
    public class RoleClaimsSeed
    {
        public static RoleClaim[] ToAdminRole()
        {
            return new RoleClaim[]
            {
                new RoleClaim {  }
            };
        }
    }
}
