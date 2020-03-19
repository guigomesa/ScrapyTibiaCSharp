
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using System.Configuration;
using Npgsql.EntityFrameworkCore;

namespace TibiaApi.Database
{
    public class TibiaContextFactory : IDesignTimeDbContextFactory<TibiaDbContext>
    {

        public TibiaDbContext CreateDbContext(string[] args)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionPostgres = configuration.GetConnectionString("TibiaPostgres");


            
            var optionsBuilder = new DbContextOptionsBuilder<TibiaDbContext>()
                .UseNpgsql(connectionPostgres);
            
            return new TibiaDbContext(optionsBuilder.Options);
        }
    }
}