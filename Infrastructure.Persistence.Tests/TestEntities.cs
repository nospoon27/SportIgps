using Application.CustomTypes;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Tests
{
    public static class TestEntities
    {
        public static List<User> TestUsers()
        {
            return new List<User>
            {
                new User
                        {
                            Id = 1,
                            FirstName = "TestFirstName",
                            LastName = "TestLastName",
                            MiddleName = "TestMiddleName",
                            Gender = new Gender { Id = 1, Name = "мужской" },
                            GenderId = Domain.Enums.GenderId.Мужской,
                            PhoneNumber = "9119407574",
                            CountryCode = new CountryCode
                            {
                                Id = 1,
                                Code = "+7",
                                ISOName = "RUS"
                            }
                },      new User
                        {
                            Id = 2,
                            FirstName = "TestFirstName",
                            LastName = "TestLastName",
                       MiddleName = "TestMiddleName",
                     Gender = new Gender { Id = 1, Name = "мужской" },
                    GenderId = Domain.Enums.GenderId.Мужской,
                     PhoneNumber = "9998887766",
                     CountryCode = new CountryCode
                     {
                         Id = 1,
                         Code = "+7",
                         ISOName = "RUS"
                     }
                }
            };
        }

        public static List<Role> TestRoles()
        {
            return new List<Role>()
            {
                new Role
                {
                    Id = (int)RoleId.admin,
                    Name = RoleId.admin.ToString()
                },
                new Role
                {
                    Id = (int)RoleId.client,
                    Name = RoleId.client.ToString()
                },
                new Role
                {
                    Id = (int)RoleId.trainer,
                    Name = RoleId.trainer.ToString()
                }
            };
        }

        public static List<RoleClaim> TestRoleClaims()
        {
            return new List<RoleClaim>()
            {
                new RoleClaim
                {
                    Id = 1,
                    ClaimType = CustomClaimTypes.Permission,
                    ClaimValue = "read",
                    Role = TestRoles().FirstOrDefault(x => x.Id == 1)
                },
                new RoleClaim
                {
                    Id = 2,
                    ClaimType = CustomClaimTypes.Permission,
                    ClaimValue = "create",
                    Role = TestRoles().FirstOrDefault(x => x.Id == 1)
                }
            };
        }
    }
}
