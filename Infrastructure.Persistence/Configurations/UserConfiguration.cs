using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly IPasswordHashService _passwordHashService;
        public UserConfiguration(IPasswordHashService passwordHashService)
        {
            _passwordHashService = passwordHashService;
        }
        public void Configure(EntityTypeBuilder<User> builder)
        {
         
        }
    }
}
