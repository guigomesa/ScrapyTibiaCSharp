using DotnetSpider.Extension.Pipeline;
using DotnetSpider.Extraction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using TibiaApi.Comum.Extensions;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Repository;
using TibiaApi.Service;

namespace TibiaApi.BotWeb.Pipelines
{
    public class WorldPipeline : EntityPipeline
    {
        public WorldPipeline()
        {
        }

        protected override int Process(List<IBaseEntity> items, dynamic sender = null)
        {
            foreach (WorldScrapy item in items)
            {
                var idJobWorld = Hangfire.BackgroundJob.Enqueue<WorldService<WorldRepository>>(srv => srv.SaveFromScrapy(item));
                if (item.PlayersUrl.Any())
                    Hangfire.BackgroundJob.Enqueue<PlayerSpider>(spider => spider.Run(item.PlayersUrl));
            }

            return items.Count;
        }
    }
}
