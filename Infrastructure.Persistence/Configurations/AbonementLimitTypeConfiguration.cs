using Domain.Entities;
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
                .HasData(new List<AbonementLimitType>()
                {
                    new AbonementLimitType { Id = 1, Name = "Ограниченный" },
                    new AbonementLimitType { Id = 1 , Name = "Безлимитный" }
                });
        }
    }
}
