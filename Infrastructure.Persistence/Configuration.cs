using Domain.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Persistence
{
    public class Configuration
    {
        public Configuration()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            ConnectionString = root.GetConnectionString("local");
        }

        public string ConnectionString { get; }
    }
}
