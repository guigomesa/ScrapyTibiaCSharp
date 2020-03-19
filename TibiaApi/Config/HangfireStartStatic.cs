using Hangfire;
using Hangfire.MySql;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using TibiaApi.Comum;
using TibiaApi.Web.Auth;
using TibiaApi.Web.HangfireJobs;

namespace TibiaApi.Web.Config
{
    public static class HangfireStartStatic
    {
        public static void StartHangfire(this IApplicationBuilder app, bool apenasScrapy, IServiceProvider serviceProvider)
        {
            var filas = apenasScrapy
                 ? new[] {
                    Constantes.FilasConstantes.WORLD_SCRAPY,
                    Constantes.FilasConstantes.PLAYER_SCRAPY,
                    Constantes.FilasConstantes.DEFAULT,
                 }
                 : new[] {
                    Constantes.FilasConstantes.WORLD_SERVICE,
                    Constantes.FilasConstantes.PLAYER_SERVICE,
                    Constantes.FilasConstantes.DEFAULT,
                    Constantes.FilasConstantes.WORLD_SCRAPY,
                    Constantes.FilasConstantes.PLAYER_SCRAPY,
                 };

            var nome = apenasScrapy ? "TIBIA_SCRAPY_" : "TIBIA_FULL_";
            //var workersCount = apenasScrapy ? 10 : 8;
            var workersCount = 10;

            var options = new BackgroundJobServerOptions()
            {
                Activator = new HangfireActivator(serviceProvider),
                Queues = filas,
                WorkerCount = workersCount,
                ServerName = $"{nome}{Environment.MachineName}_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6)}"
            };

            app.UseHangfireServer(options);


            if (!apenasScrapy)
            {
                app.UseHangfireDashboard("/hangfire", new DashboardOptions()
                {
                    Authorization = new[] { new HangfireAutorizationFilter() }
                });
            }
        }

        public static void StartServiceHangfire(this IServiceCollection services, string connection)
        {
            services
                    .AddHangfire(x =>
                    x.UseStorage(
                        new PostgreSqlStorage(connection)));
        }
    }


}
