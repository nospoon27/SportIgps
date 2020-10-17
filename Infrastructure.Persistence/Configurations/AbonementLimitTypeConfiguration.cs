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
            
        }
    }
}
