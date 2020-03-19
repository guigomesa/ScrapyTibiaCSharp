using System;

namespace TibiaApi.Comum.ScrapyModels
{
    public class MonsterStatScrapy : BasicScrapy
    {
        public string Name { get; set; }
        public int KilledPlayer { get; set; }
        public int KilledByPlayer { get; set; }
        public DateTime DateScrapy { get; set; }
    }
}