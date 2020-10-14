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
    public class AccessCardTypeConfiguration : IEntityTypeConfiguration<AccessCardType>
    {
        public void Configure(EntityTypeBuilder<AccessCardType> builder)
        {
            builder
                .Property(x => x.Id)
                .HasConversion<int>();

            builder
                .HasData(
                Enum.GetValues(typeof(AccessCardTypeId))
                .Cast<AccessCardTypeId>()
                .Select(@enum => new AccessCardType
                {
                    Id = (int)@enum,
                    Name = @enum.ToString()
                }));
        }
    }
}
