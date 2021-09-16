using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using TibiaApi.Comum;

namespace TibiaApi.Web.Config
{
    public static class HangfireStartStatic
    {
        public static void StartHangfire(this IApplicationBuilder app, bool apenasDashboard, IServiceProvider serviceProvider)
        {
            var workersCount = Environment.ProcessorCount * 10;

            //if (apenasDashboard)
            //    workersCount = 1;

            //var filas = apenasDashboard
            //     ? new[] { Constantes.FilasHangfire.DEFAULT }
            //     :
            var filas = new[] {
                    Constantes.FilasHangfire.WORLD_SERVICE,
                    Constantes.FilasHangfire.PLAYER_SERVICE,
                    Constantes.FilasHangfire.DEFAULT,
                    Constantes.FilasHangfire.WORLD_SCRAPY,
                    Constantes.FilasHangfire.PLAYER_SCRAPY,
                 };

            var nome = apenasDashboard ? "TIBIA_DASHBOARD_API_" : "TIBIA_FULL_";

            BackgroundJobServerOptions options = CreateOptionsBackgroundServer(serviceProvider, filas, nome, workersCount);

            app.UseHangfireServer(options);
        }

        public static void StartDashboardHangfire(this IApplicationBuilder app)
        {
            var optionsDashboard = new DashboardOptions()
            {
                Authorization = new[] { new Auth.HangfireAutorizationFilter() },
            };

            app.UseHangfireDashboard("/hangfire", optionsDashboard);
        }

        private static BackgroundJobServerOptions CreateOptionsBackgroundServer(IServiceProvider serviceProvider, string[] filas, string nome, int workersCount)
        {
            return new BackgroundJobServerOptions()
            {
                //Activator = new HangfireActivator(serviceProvider),
                Queues = filas,
                WorkerCount = workersCount,
                ServerName = $"{nome}{Environment.MachineName}_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6)}",

            };
        }

        public static void StartServiceHangfire(this IServiceCollection services, ConnectionMultiplexer redis)
        {
            services
                    .AddHangfire(x =>
                    x.UseRedisStorage(redis)
                    );
        }

        private static Action<BackgroundJobServerOptions> BackgroundServerHangfire(IServiceProvider serviceProvider, string[] filas, string nome, int workersCount)
        {
            return x =>
            {
                x.Queues = filas;
                x.WorkerCount = workersCount;
                x.ServerName = $"{nome}{Environment.MachineName}_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6)}";
            };
        }

        public static JobStorage GenerateJobStorage(string connectionString) => new PostgreSqlStorage(connectionString);

        public static BackgroundJobServer CreateBackgroundJobServer(IServiceProvider serviceProvider, string connectionString)
        {
            var filas = new[] {
                    Constantes.FilasHangfire.WORLD_SCRAPY,
                    Constantes.FilasHangfire.PLAYER_SCRAPY,
                    Constantes.FilasHangfire.WORLD_SERVICE,
                    Constantes.FilasHangfire.PLAYER_SERVICE,
                    Constantes.FilasHangfire.DEFAULT,

                 };

            var options = CreateOptionsBackgroundServer(serviceProvider, filas, "MAQUINA_JOB_", 10);

            return new BackgroundJobServer(options, GenerateJobStorage(connectionString));
        }
    }


}
