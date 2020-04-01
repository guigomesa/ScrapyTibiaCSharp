using System;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace TibiaApi
{
    public static class ObjectFactoryTibia
    {
        public static IServiceProvider Instance { get; private set; }
        public static AsyncLocal<HttpContext> Context = new AsyncLocal<HttpContext>();

        public static void Init(IServiceProvider provider)
        {
            Instance = provider.CreateScope().ServiceProvider;
        }

        public static T Obter<T>()
        {
            try
            {
                return (T)Context.Value.RequestServices.GetService(typeof(T));
            }
            catch(Exception)
            {
                try
                {
                    return (T)Instance.GetService(typeof(T));
                }
                catch(Exception)
                {
                    throw new Exception($"O objeto {typeof(T).FullName} não foi encontrado");
                }
            }
        }
    }
}
