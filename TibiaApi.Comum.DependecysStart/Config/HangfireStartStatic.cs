using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using TibiaApi.Comum;
using TibiaApi.Web.HangfireJobs;

namespace TibiaApi.Web.Config
{
    public static class HangfireStartStatic
    {
        public static void StartHangfire(this IApplicationBuilder app, bool apenasServer, IServiceProvider serviceProvider)
        {
            var filas = apenasServer
                 ? new string[0]
                 : new[] {
                    Constantes.FilasHangfire.WORLD_SERVICE,
                    Constantes.FilasHangfire.PLAYER_SERVICE,
                    Constantes.FilasHangfire.DEFAULT,
                    Constantes.FilasHangfire.WORLD_SCRAPY,
                    Constantes.FilasHangfire.PLAYER_SCRAPY,
                 };

            var nome = apenasServer ? "TIBIA_SERVER_API_" : "TIBIA_FULL_";
            //var workersCount = apenasScrapy ? 10 : 8;
            var workersCount = 10;
            BackgroundJobServerOptions options = CreateOptionsBackgroundServer(serviceProvider, filas, nome, workersCount);

            app.UseHangfireServer(options);
        }

        private static BackgroundJobServerOptions CreateOptionsBackgroundServer(IServiceProvider serviceProvider, string[] filas, string nome, int workersCount)
        {
            return new BackgroundJobServerOptions()
            {
                Activator = new HangfireActivator(serviceProvider),
                Queues = filas,
                WorkerCount = workersCount,
                ServerName = $"{nome}{Environment.MachineName}_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6)}"
            };
        }

        public static void StartServiceHangfire(this IServiceCollection services, string connection)
        {
            services
                    .AddHangfire(x =>
                    x.UseStorage(
                        GenerateJobStorage(connection)));
        }

        public static JobStorage GenerateJobStorage(string connectionString) => new PostgreSqlStorage(connectionString);

        public static BackgroundJobServer CreateBackgroundJobServer(IServiceProvider serviceProvider, string connectionString)
        {
            var filas = new[] {
                    Constantes.FilasHangfire.WORLD_SERVICE,
                    Constantes.FilasHangfire.PLAYER_SERVICE,
                    Constantes.FilasHangfire.DEFAULT,
                    Constantes.FilasHangfire.WORLD_SCRAPY,
                    Constantes.FilasHangfire.PLAYER_SCRAPY,
                 };

            var options = CreateOptionsBackgroundServer(serviceProvider, filas, "MAQUINA_JOB_", 10);

            return new BackgroundJobServer(options, GenerateJobStorage(connectionString));
        }
    }


}
