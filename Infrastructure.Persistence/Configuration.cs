using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Persistence
{
    public class Configuration
    {
        private readonly string _connectionString;
        public Configuration()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            _connectionString = root.GetConnectionString("local");
        }

        public string ConnectionString { get => _connectionString; }
    }
}
