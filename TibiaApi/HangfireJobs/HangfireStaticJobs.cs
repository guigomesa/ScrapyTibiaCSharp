using TibiaApi.BotWeb;

namespace TibiaApi.Web.HangfireJobs
{
    public static class HangfireStaticJobs
    {
        public static void StartRecorrentes()
        {
            Hangfire.RecurringJob.AddOrUpdate<WorldListSpider>(spider => spider.Run(), Hangfire.Cron.HourInterval(18));
        }
    }
}
