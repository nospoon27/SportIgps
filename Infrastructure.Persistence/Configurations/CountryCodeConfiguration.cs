using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class CountryCodeConfiguration : IEntityTypeConfiguration<CountryCode>
    {
        public void Configure(EntityTypeBuilder<CountryCode> builder)
        {
            builder
                .HasData(new List<CountryCode>
                {
                    new CountryCode { Id = 1, Code = "+7", ISOName = "RUS" },
                    new CountryCode { Id = 2, Code = "+380", ISOName = "UKR" },
                    new CountryCode { Id = 3, Code = "+374", ISOName = "ARM" },
                    new CountryCode { Id = 4, Code = "+994", ISOName = "AZE" },
                    new CountryCode { Id = 5, Code = "+375", ISOName = "BLR" },
                    new CountryCode { Id = 6, Code = "+359", ISOName = "BGR" },
                    new CountryCode { Id = 7, Code = "+7", ISOName = "KAZ" },
                    new CountryCode { Id = 8, Code = "+996", ISOName = "KGZ" },
                    new CountryCode { Id = 9, Code = "+381", ISOName = "SRB" },
                    new CountryCode { Id = 10, Code = "+82", ISOName = "KOR" },
                });
        }
    }
}
