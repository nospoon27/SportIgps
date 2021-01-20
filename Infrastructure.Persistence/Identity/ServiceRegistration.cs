using Application.Wrappers;
using Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Persistence.Identity
{
    public static class ServiceRegistration
    {
        public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            // RsaSecurityKey service
            services.AddSingleton(provider =>
            {
                RSA rsa = RSA.Create();
                rsa.ImportRSAPublicKey(
                    source: Convert.FromBase64String(configuration["JWTSettings:PublicKey"]),
                    bytesRead: out int _
                );

                return new RsaSecurityKey(rsa);
            });
            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            services.Configure<PathSettings>(configuration.GetSection("PathSettings"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                {
                    SecurityKey rsa = services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>();
                    //using var rsa = RSA.Create();
                    //rsa.ImportRSAPrivateKey(Convert.FromBase64String(Configuration["Jwt:Asymmetric:PrivateKey"]), out int _);

                    options.IncludeErrorDetails = true; // <- great for debugging
                    //options.SaveToken = false;
                    //options.RequireHttpsMetadata = false;

                    // Configure the actual Bearer validation
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //IssuerSigningKey = new RsaSecurityKey(rsa),
                        IssuerSigningKey = rsa,
                        ValidAudience = "jwt",
                        ValidIssuer = "jwt",
                        RequireSignedTokens = true,
                        RequireExpirationTime = true, // <- JWTs are required to have "exp" property set
                        ValidateLifetime = true, // <- the "exp" will be validated
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        
                    };
                    var jsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                    options.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = context =>
                        {
                            context.NoResult();
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(new Response<string>("Ошибка аутентификации"), jsonSettings);
                            return context.Response.WriteAsync(result);
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(new Response<string>("Вы не авторизованы"), jsonSettings);
                            return context.Response.WriteAsync(result);
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(new Response<string>("У вас нет доступа для этого ресурса"), jsonSettings);
                            return context.Response.WriteAsync(result);
                        },
                    };
                });
        }
    }
}
