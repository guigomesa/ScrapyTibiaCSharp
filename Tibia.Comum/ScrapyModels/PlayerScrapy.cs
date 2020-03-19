using DotnetSpider.Extraction.Model.Attribute;
using System;
using System.Collections.Generic;
using TibiaApi.Comum.Extensions;
using TibiaApi.Comum.Utils;

namespace TibiaApi.Comum.ScrapyModels
{
    [Entity(Expression = "/html[1]", Type = DotnetSpider.Extraction.SelectorType.XPath)]
    public class PlayerScrapy : BasicScrapy
    {
        [Field(Expression = "//td[@width='20%'][contains(text(),'Name:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath, Option = DotnetSpider.Extraction.Model.FieldOptions.InnerText)]
        public string Name { get; set; }

        [Field(Expression = "//td[contains(text(),'Former Names:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath, Option = DotnetSpider.Extraction.Model.FieldOptions.InnerText)]
        public string OlderName { get; set; }

        [Field(Expression = "//td[contains(text(),'Sex:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath, Option = DotnetSpider.Extraction.Model.FieldOptions.InnerText)]
        public string SexStr
        {
            set
            {
                if (value.ToLower().Contains("female"))
                {
                    Sex = Sex.Female;
                    return;
                }
                else if (value.ToLower() == "male")
                    Sex = Sex.Male;
            }
        }

        public Sex Sex { get; set; }

        [Field(Expression = "//td[contains(text(),'Vocation:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath, Option = DotnetSpider.Extraction.Model.FieldOptions.InnerText)]
        public string ProfessionStr
        {
            set
            {
                Profession = EnumExtensions.ProfessionSite(value);
            }
        }
        public Profession Profession { get; set; }

        [Field(Expression = "//td[contains(text(),'Level:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath, Option = DotnetSpider.Extraction.Model.FieldOptions.InnerText)]
        public int Level { get; set; }

        [Field(Expression = "//td[contains(text(),'World:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath, Option = DotnetSpider.Extraction.Model.FieldOptions.InnerText)]
        public string WorldName { get; set; }

        public int AchievementPoints { get; set; }

        [Field(Expression = "//td[contains(text(),'Residence:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public string CityResidence { get; set; }

        [Field(Expression = "//td[contains(text(),'House:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public string House { get; set; }

        public string Guild { get; set; }

        [Field(Expression = "//td[contains(text(),'Last Login:')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public string LastLoginStr
        {
            set { LastLogin = DateTimeExtensions.ConvertDateFromSite(value); }
        }
        public DateTime LastLogin { get; set; }

        [Field(Expression = "//table/tbody/tr/td[contains(text(),'Account')]/following-sibling::td[1]", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public string AccountStatus { get; set; }
        public string AccountInfo { get; set; }
        public DateTime AccountCreation { get; set; }
        public DateTime ScrapyData { get; set; } = DateTime.Now;

        public IEnumerable<AchievmentPlayerScrapy> Achievements { get; set; }

        [Field(Expression = "//div[@class='BoxContent']//table[3]/tbody/tr[@bgcolor='#F1E0C6' or @bgcolor='#D4C0A1']", Type = DotnetSpider.Extraction.SelectorType.XPath)]
        public IEnumerable<DeathPlayerScrapy> Deaths { get; set; }

    }
}