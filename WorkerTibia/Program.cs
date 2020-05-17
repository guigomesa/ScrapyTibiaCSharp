using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TibiaApi.Web.Config;

namespace WorkerTibia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static Hangfire.BackgroundJobServer HangfireServer { get; set; }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;

                    services.RegisterDatabase(configuration);
                    services.RegisterDependenciesScan(configuration);

                    var connection = configuration.GetConnectionString("TibiaPostgres");

                   var serviceProvider = configuration.Get<IServiceProvider>();

                    HangfireServer =  HangfireStartStatic.CreateBackgroundJobServer(serviceProvider, connection);

                    services.AddHostedService<Worker>();
                });
    }
}
