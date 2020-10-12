using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Persistence.Identity.AccessControl
{
    public static class Permissions
    {
        public static class Users
        {
            public const string Read = "can.users.read";
        }
    }
}
