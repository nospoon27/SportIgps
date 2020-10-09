using Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations.DbContextFactory
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<SportDbContext>
    {
        public DbContextFactory()
        {

        }
        public DbContextFactory(IAuthenticatedUserService authenticatedUser) : base(authenticatedUser)
        {
        }

        protected override SportDbContext CreateNewInstance(DbContextOptions<SportDbContext> options, IAuthenticatedUserService authenticatedUser)
        {
            return new SportDbContext(options, authenticatedUser);
        }
    }
}
