﻿using Domain.Entities;
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
            
        }
    }
}
