using DotnetSpider.Extraction.Model.Attribute;
using System;
using TibiaApi.Comum.Utils;

namespace TibiaApi.Comum.ScrapyModels
{

    [Entity(Expression = "//tr[@class='Odd' or @class='Even']", Type = DotnetSpider.Extraction.SelectorType.XPath)]
    public class WorldListScrapy : BasicScrapy
    {
        [Field(Expression = "td/a/text()", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public string Name { get; set; }

        [Field(Expression = "td[2]/text()", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public int NumberPlayersOnline { get; set; }

        [Field(Expression = "td/a/@href", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public string Url { get; set; }
    }
}