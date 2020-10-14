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
    public class AbonementLimitTypeConfiguration : IEntityTypeConfiguration<AbonementLimitType>
    {
        public void Configure(EntityTypeBuilder<AbonementLimitType> builder)
        {
            builder
                .Property(x => x.Id)
                .HasConversion<int>();

            builder
                .HasData(
                Enum.GetValues(typeof(GenderId))
                .Cast<AbonementLimitTypeId>()
                .Select(@enum => new AbonementLimitType
                {
                   Id = (int)@enum,
                   Name = @enum.ToString()
                }));
        }
    }
}
