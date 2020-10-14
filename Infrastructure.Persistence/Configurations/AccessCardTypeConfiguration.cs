using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class AccessCardTypeConfiguration : IEntityTypeConfiguration<AccessCardType>
    {
        public void Configure(EntityTypeBuilder<AccessCardType> builder)
        {
            builder
                .Property(x => x.Id)
                .HasConversion<int>();

            builder
                .HasData(new List<AccessCardType>()
                {
                    new AccessCardType { Id = 1, Name = "Ограниченный" },
                    new AccessCardType { Id = 1 , Name = "Свободный" }
                });
        }
    }
}
