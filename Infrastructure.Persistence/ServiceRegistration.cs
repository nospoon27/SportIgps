using Application.Interfaces.Services;
using Domain.Settings;
using Infrastructure.Persistence.Identity.Services;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
            Configuration config = new Configuration();

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            services.AddDbContext<SportDbContext>(options =>
            {
                options.UseNpgsql(config.ConnectionString, b => b.MigrationsAssembly(typeof(SportDbContext).FullName));
            }).AddUnitOfWork<SportDbContext>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPasswordHashService, PasswordHashService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICountryCodeService, CountryCodeService>();
            services.AddIdentity(configuration);
        }
    }
}
