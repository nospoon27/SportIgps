using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .Property(x => x.Id)
                .HasConversion<int>();

            builder
                .HasData(new List<Role>
                {
                    new Role { Id = 1, Name = "admin" },
                    new Role { Id = 2, Name = "manager" },
                    new Role { Id = 3, Name = "trainer" },
                    new Role { Id = 4, Name = "client" }
                });
        }
    }
}
