using DotnetSpider.Core;
using DotnetSpider.Core.Processor.Filter;
using DotnetSpider.Downloader;
using DotnetSpider.Extension;
using DotnetSpider.Extension.Pipeline;
using DotnetSpider.Extraction.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TibiaApi.BotWeb.Pipelines;
using TibiaApi.Comum.ScrapyModels;

namespace TibiaApi.BotWeb
{
    public class WorldListSpider : EntitySpider
    {

        public WorldListSpider()
        {
        }

        protected override void OnInit(params string[] arguments)
        {
            AddRequest(new Request("https://www.tibia.com/community/?subtopic=worlds"));
            AddEntityType<WorldListScrapy>();
            //AddPipeline(new ConsoleEntityPipeline());
            AddPipeline(new WorldListPipeline());
            

            base.OnInit(arguments);
        }

    }
}
