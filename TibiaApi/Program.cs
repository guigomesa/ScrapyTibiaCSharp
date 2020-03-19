using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace TibiaApi.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args =null)
        {
            return WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
             .UseStartup<Startup>()
             //.UseUrls("http://0.0.0.0:80")
             //.ConfigureLogging((hostingContext, logging) =>
             //{
             //    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
             //    logging.AddConsole();
             //    logging.AddDebug();
             //})
                .Build();
        }
    }
}