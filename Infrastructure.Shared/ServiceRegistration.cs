﻿using Application.Interfaces.Services;
using Infrastructure.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
        }
    }
}
