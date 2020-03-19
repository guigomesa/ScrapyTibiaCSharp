using DotnetSpider.Extraction.Model.Attribute;
using DotnetSpider.Extraction.Model.Formatter;
using System;
using System.Collections.Generic;
using TibiaApi.Comum.Extensions;
using TibiaApi.Comum.Utils;

namespace TibiaApi.Comum.ScrapyModels
{
    [Entity(Expression = "/html[1]", Type = DotnetSpider.Extraction.SelectorType.XPath)]
    public class WorldScrapy : BasicScrapy
    {
        [Field(Expression = "//select[@name='world']/option[@selected='selected']", Type = DotnetSpider.Extraction.SelectorType.XPath,
            Option = DotnetSpider.Extraction.Model.FieldOptions.InnerText)]
        public string Name { get; set; }
        [Field(Expression = "//td[contains(text(),'Players Online:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public int NumberPlayersOnline { get; set; }

        public int MaxPlayerOnline { get; set; }
        [Field(Expression = "//td[contains(text(),'Location:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath, Option = DotnetSpider.Extraction.Model.FieldOptions.InnerText)]
        public string Location { get; set; }

        [Field(Expression = "//td[contains(text(),'PvP Type:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public string PvpStyleStr
        {
            set
            {
                PvpStyle = EnumExtensions.PvpSite(value);
            }
        }

        public PvpType PvpStyle { get; set; }

        public string AditionalInformation { get; set; }

        public WorldTransferStatus StatusWorldTransfer { get; set; }

        public StatusWorld StatusWorld { get; set; }

        public DateTime ScrapyData { get; set; } = DateTime.Now;

        public string Url { get; set; }
        [Field(Expression = "//tr[@class=\"Odd\" or @class=\"Even\"]/td/a/@href",
            Type = DotnetSpider.Extraction.SelectorType.XPath
            )]
        
        public List<string> PlayersUrl { get; set; } = new List<string>();
    }
}