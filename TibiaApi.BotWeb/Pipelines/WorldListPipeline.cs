using DotnetSpider.Extension.Pipeline;
using DotnetSpider.Extraction.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TibiaApi.Comum;
using TibiaApi.Comum.ScrapyModels;

namespace TibiaApi.BotWeb.Pipelines
{
    public class WorldListPipeline : EntityPipeline
    {
        public WorldListPipeline()
        {
        }

        protected override int Process(List<IBaseEntity> items, dynamic sender = null)
        {
            var urls = items.Select(v => new { ((WorldListScrapy)v).Url, ((WorldListScrapy)v).Name }).ToList();

            foreach (var url in urls)
            {
                Hangfire.RecurringJob.AddOrUpdate<WorldSpider>(url.Name, spider=> spider.Run(url.Url), Hangfire.Cron.HourInterval(1), queue: Constantes.FilasConstantes.WORLD_SCRAPY);
            }

            return items.Count;
        }
    }
}
