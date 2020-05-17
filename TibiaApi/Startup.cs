using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
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
            
            services.AddMvc(options => {

                options.EnableEndpointRouting = false;
                
            });

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MapperConfig());


            }, typeof(Startup));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Description = "Api for Tibia",
                    Title = "Api Tibia",
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(serviceProvider));


            var apenasServer = Configuration.GetValue<bool>("apenasscrapy", true);



            app.StartHangfire(apenasServer, serviceProvider);

            var cs = Configuration.GetConnectionString("TibiaPostgres");

            app.StartDashboardHangfire(cs);

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