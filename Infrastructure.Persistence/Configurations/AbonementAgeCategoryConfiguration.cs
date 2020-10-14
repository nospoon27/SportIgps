using Domain.Entities;
using Domain.Enums;
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
                Enum.GetValues(typeof(AbonementAgeCategoryId))
                .Cast<AbonementAgeCategoryId>()
                .Select(@enum => new AbonementAgeCategory()
                {
                    Id = (int)@enum,
                    Name = @enum.ToString()
                }));
        }
    }
}
