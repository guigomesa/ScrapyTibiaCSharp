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
                Hangfire.BackgroundJob.Enqueue<WorldService<WorldRepository>>(srv => srv.SaveFromScrapy(item));
                if (item.PlayersUrl.Any())
                {
                    foreach (var urls in item.PlayersUrl.Chunk(25).ToList())
                    {
                        Hangfire.BackgroundJob.Enqueue<PlayerSpider>(spider => spider.Run(urls.ToList()));
                    }
                }
            }

            return items.Count;
        }
    }
}
