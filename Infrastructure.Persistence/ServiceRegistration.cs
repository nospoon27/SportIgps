using Application.Interfaces.Services;
using Infrastructure.Persistence.Identity.Services;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        /// <summary>
        /// Добавляет сервисы связанные с БД, включая Unit Of Work
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SportDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("local"), b => b.MigrationsAssembly(typeof(SportDbContext).FullName));
            }).AddUnitOfWork<SportDbContext>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPasswordHashService, PasswordHashService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
