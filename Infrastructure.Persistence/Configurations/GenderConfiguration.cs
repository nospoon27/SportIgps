using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder
                .Property(x => x.Id)
                .HasConversion<int>();

            builder
                .HasData(new List<Gender>()
                {
                    new Gender { Id = 1, Name = "Мужской" },
                    new Gender { Id = 2, Name = "Женский" }
                });
        }
    }
}
