using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class AbonementAgeCategoryConfiguration : IEntityTypeConfiguration<AbonementAgeCategory>
    {
        public void Configure(EntityTypeBuilder<AbonementAgeCategory> builder)
        {
            builder
                .Property(x => x.Id)
                .HasConversion<int>();

            builder
                .HasData(
                new List<AbonementAgeCategory>()
                {
                    new AbonementAgeCategory { Id = 1, Name = "Взрослый" },
                    new AbonementAgeCategory { Id = 2, Name = "Детский" }
                });
        }
    }
}
