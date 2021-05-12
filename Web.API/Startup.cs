using Application;
using Application.DTOs.Account.Validation;
using Application.Interfaces.Services;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using Infrastructure.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using Web.API.Extensions;
using Web.API.Filters;
using Web.API.Handlers;
using Web.API.Providers;
using Web.API.Services;
using NLog.Web;
using Web.API.Middlewares;

namespace Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;

                o.ValueCountLimit = int.MaxValue;
            });

            // HttpContextAccessor (Context DI)
            services.AddHttpContextAccessor();

            services.AddApplicationLayer(Configuration);

            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();

            services.AddControllers(options =>
            {
                options.Filters.Add(new OverridingResultFilter());
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                options.SuppressMapClientErrors = true;
            })
            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterRequestValidator>());

            services.AddCors();

            // Swagger
            services.AddSwaggerExtension();
            
            services.AddApiVersioningExtension();

            services.AddPersistenceInfrastructure(Configuration);
            services.AddSharedInfrastructure();

            services.AddRouting();
            
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

            services.AddTransient<IValidatorInterceptor, ValidatorInterceptor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // swagger
            app.UseConfiguredSwagger();

            // Мой обработчик ошибок
            app.UseErrorHandlingMiddleware();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowCredentials().AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            // configure path for static files
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data")),
            //    RequestPath = new PathString("/data"),
            //});

            //app.UseDirectoryBrowser(new DirectoryBrowserOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data")),
            //    RequestPath = new PathString("/data"),
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/v{version:apiVersion}/{controller}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
