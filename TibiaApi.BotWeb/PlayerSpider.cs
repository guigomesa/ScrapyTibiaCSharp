using DotnetSpider.Downloader;
using DotnetSpider.Extension;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaApi.BotWeb.Pipelines;
using TibiaApi.Comum.Extensions;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Repository;
using TibiaApi.Service;
using static TibiaApi.Comum.Constantes;

namespace TibiaApi.BotWeb
{
    public class PlayerSpider : EntitySpider
    {
        public IList<string> UrlsPlayers { get; }

        public PlayerSpider()
        {
            UrlsPlayers = new List<string>();
        }

        public PlayerSpider(List<string> urlsPlayers) : base()
        {
            UrlsPlayers = urlsPlayers;
        }

        [Queue(FilasHangfire.PLAYER_SCRAPY)]
        public void Run(IList<string> urlPlayers)
        {
            AddRequests(urlPlayers.Select(v => new Request(v)).ToList());

            base.Run();
        }

        protected override void OnInit(params string[] arguments)
        {
            foreach (var url in UrlsPlayers)
            {
                AddRequest(new Request(url));
            }

            AddEntityType<PlayerScrapy>();
            AddPipeline(new PlayerPipeline());

            this.EncodingName = "UTF-8";
            base.OnInit(arguments);
        }
    }
}
