using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaApi.Comum.ScrapyModels;

namespace TibiaApi.BotWeb.Processors
{
    public class WorldProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            var pagina = page.Selectable().XPath("/html[1]").Nodes().FirstOrDefault();

            var mundo = new WorldScrapy();

            mundo.Name = pagina.XPath("//select[@name='world']/option[@selected='selected']").GetValue();

            if (int.TryParse(pagina.XPath("//td[contains(text(),'Players Online:')]/following-sibling::td[1]").GetValue(), out var playerOnline))
                mundo.NumberPlayersOnline = playerOnline;

            if (int.TryParse(pagina.XPath("//td[contains(text(),'Players Online:')]/following-sibling::td[1]").GetValue(), out var maxPlayer))
                mundo.MaxPlayerOnline = maxPlayer;

            mundo.Location = pagina.XPath("//td[contains(text(),'Location:')]/following-sibling::td[1]").GetValue();

            mundo.PvpStyleStr = pagina.XPath("//td[contains(text(),'PvP Type:')]/following-sibling::td[1]").GetValue();

            var playersUrls = pagina.XPath("//tr[@class=\"Odd\" or @class=\"Even\"]/td/a/@href").GetValues();

            mundo.PlayersUrl = playersUrls.ToList();

            page.AddResultItem("Worlds", mundo);

        }
    }
}
