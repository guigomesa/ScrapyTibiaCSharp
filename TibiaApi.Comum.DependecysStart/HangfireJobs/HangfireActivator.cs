using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;


namespace TibiaApi.Web.HangfireJobs
{
    public class HangfireActivator : Hangfire.JobActivator
    {
        private readonly IServiceProvider _serviceProvider;

        public HangfireActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public override object ActivateJob(Type jobType)
        {
            return _serviceProvider.GetRequiredService(jobType);
        }
    }
}
