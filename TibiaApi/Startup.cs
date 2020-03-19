using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TibiaApi.Comum;
using TibiaApi.Web.Auth;
using TibiaApi.Web.Config;
using TibiaApi.Web.HangfireJobs;

namespace TibiaApi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterDatabase(Configuration);
            services.RegisterDependenciesScan(Configuration);

            var connection = Configuration.GetConnectionString("TibiaPostgres");

            services.StartServiceHangfire(connection);

            services.AddMvc();

            services.AddAutoMapper();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "TibiaApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(serviceProvider));


            var apenasScrapy = Configuration.GetValue<bool>("apenasscrapy", false);

            

            app.StartHangfire(apenasScrapy, serviceProvider);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tibia Api");
            });
            app.UseMvc();

            ObjectFactoryTibia.Init(serviceProvider);
            HangfireStaticJobs.StartRecorrentes();
        }
    }
}