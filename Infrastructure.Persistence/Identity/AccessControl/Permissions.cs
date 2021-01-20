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
            public const string Read = "Permissions.Users.Read";
        }

        public static class Locations
        {
            public const string Read = "Permissions.Locations.Read";
            public const string CreateUpdateDelete = "Permissions.Locations.CreateUpdateDelete";
        }

        public static class Files
        {
            public const string ReadAll = "Permissions.Files.ReadAll";
        }
    }
}
