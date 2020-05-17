using Hangfire.Annotations;
using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TibiaApi.Web.Auth
{
    public class HangfireAutorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
