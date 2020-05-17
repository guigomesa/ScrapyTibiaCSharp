using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;
using TibiaApi.Database;

namespace TibiaApi.Web.Config
{
    public static class RegisterDependencies
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("TibiaPostgres");
            
            services.AddLogging();

            services.AddDbContextPool<TibiaDbContext>(options => options.UseNpgsql(connection),poolSize: 3);
        }

        
        public static void RegisterDependenciesScan(this IServiceCollection services, IConfiguration configuration)
        {
            var assemlyNet = Assembly.GetExecutingAssembly();
            var srvAssemlby = Assembly.Load("TibiaApi.Service");
            var repoAssemlby = Assembly.Load("TibiaApi.Repository");


            var reps = services.RegisterAssemblyPublicNonGenericClasses(assemlyNet, srvAssemlby, repoAssemlby)
                .Where(c => c.Name.EndsWith("Repository"));

            reps.AsPublicImplementedInterfaces(ServiceLifetime.Scoped);


            var srvs = services.RegisterAssemblyPublicNonGenericClasses(assemlyNet, srvAssemlby, repoAssemlby)
           .Where(c => c.Name.EndsWith("Service"));

            srvs.AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

        }
    }
}
