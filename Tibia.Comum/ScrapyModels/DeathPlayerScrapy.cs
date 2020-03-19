using DotnetSpider.Extraction.Model.Attribute;
using System;
using System.Globalization;
using TibiaApi.Comum.Extensions;

namespace TibiaApi.Comum.ScrapyModels

{
    [Entity(Expression = "//div[@class='BoxContent']//table[3]/tbody/tr[@bgcolor='#F1E0C6' or @bgcolor='#D4C0A1']", Type = DotnetSpider.Extraction.SelectorType.XPath)]
    public class DeathPlayerScrapy : BasicScrapy
    {
        [Field(Expression = "/td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public string DeathDateStr {
            set => DeathDate = DateTimeExtensions.ConvertDateFromSite(value);
        }

        public DateTime DeathDate { get; set; }

        [Field(Expression = "/td[2]", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public string DeathCause { get; set; }

        public int Level { get; set; }

        public string MonsterCause { get; set; }

        public string PlayerCause { get; set; }
    }
}