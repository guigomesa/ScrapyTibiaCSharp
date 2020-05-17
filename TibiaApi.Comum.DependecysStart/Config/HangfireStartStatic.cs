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
        public static void StartHangfire(this IApplicationBuilder app, bool apenasDashboard, IServiceProvider serviceProvider)
        {
            var workersCount = 10;

            if (apenasDashboard)
                workersCount = 1;

            var filas = apenasDashboard
                 ? new[] { Constantes.FilasHangfire.DEFAULT }
                 : new[] {
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

        public static void StartDashboardHangfire(this IApplicationBuilder app, string connectionString)
        {
            var optionsDashboard = new DashboardOptions()
            {
                Authorization = new[] { new Auth.HangfireAutorizationFilter() },
            };

            app.UseHangfireDashboard("/hangfire", optionsDashboard, GenerateJobStorage(connectionString));
        }

        private static BackgroundJobServerOptions CreateOptionsBackgroundServer(IServiceProvider serviceProvider, string[] filas, string nome, int workersCount)
        {
            return new BackgroundJobServerOptions()
            {
                Activator = new HangfireActivator(serviceProvider),
                Queues = filas,
                WorkerCount = workersCount,
                ServerName = $"{nome}{Environment.MachineName}_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6)}",
                
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
