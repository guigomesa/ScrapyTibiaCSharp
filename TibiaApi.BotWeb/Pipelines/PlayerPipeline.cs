using DotnetSpider.Extension.Pipeline;
using DotnetSpider.Extraction.Model;
using System.Collections.Generic;
using System.Linq;
using TibiaApi.Comum.Extensions;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Repository;
using TibiaApi.Service;

namespace TibiaApi.BotWeb.Pipelines
{
    public class PlayerPipeline : EntityPipeline
    {
        public PlayerPipeline()
        {
        }

        protected override int Process(List<IBaseEntity> items, dynamic sender = null)
        {
            foreach(var players in items.Chunk(10).ToList())
            {
                var itensJob = players.Select(v => (PlayerScrapy)v).ToList();

                Hangfire.BackgroundJob.Enqueue<PlayerService<PlayerRepository>>(srv => srv.SaveFromScrapy(itensJob));
            }

            return items.Count;
        }
    }
}
