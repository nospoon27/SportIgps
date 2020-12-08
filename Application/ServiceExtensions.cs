using Application.Mappings;
using Application.Sieve.Models;
using Application.Sieve.Services;
using Application.SieveProcessors;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddAutoMapper(typeof(LocationMapper));
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddScoped<SieveProcessor>();
            services.Configure<SieveOptions>(configuration.GetSection("Sieve"));
            services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
