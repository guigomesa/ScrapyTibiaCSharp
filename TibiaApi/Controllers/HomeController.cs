using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using TibiaApi.Database;
using TibiaApi.Repository;
using TibiaApi.Service;
using TibiaApi.Web.HangfireJobs;

namespace TibiaApi.Web.Controllers
{
    [Route("[controller]")]

    public class HomeController : Controller
    {
        private IServiceProvider _provider;

        public HomeController(IServiceProvider provider)
        {
            _provider = provider;
        }
        [Route("")]

        public string Index()
        {
            return "Alive";
        }

        [Route("recorrentes")]

        public string Recorrentes()
        {
            try
            {
                return DateTime.Now.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
                //return ex.Message;
            }


        }
    }
}