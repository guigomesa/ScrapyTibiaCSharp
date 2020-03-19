using DotnetSpider.Downloader;
using DotnetSpider.Extension;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaApi.BotWeb.Pipelines;
using TibiaApi.BotWeb.Processors;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Repository;
using TibiaApi.Service;
using static TibiaApi.Comum.Constantes;

namespace TibiaApi.BotWeb
{
    public class WorldSpider: EntitySpider
    {
        public IList<string> UrlWorld { get; }

        public WorldSpider()
        {
            UrlWorld = new List<string>();
        }

        public WorldSpider(IList<string> urlWorld) : base()
        {
            UrlWorld = urlWorld;
        }

        [Queue(FilasConstantes.WORLD_SCRAPY)]
        public void Run(string url)
        {
            AddRequest(new Request(url));
            base.Run();
        }

        protected override void OnInit(params string[] arguments)
        {
            AddRequests(UrlWorld.Select(v => new Request(v)).ToList());
            AddPageProcessor(new WorldProcessor());
            AddEntityType<WorldScrapy>();

            this.EncodingName = "UTF-8";
            AddPipeline(new WorldPipeline());

            base.OnInit(arguments);
        }
    }
}
