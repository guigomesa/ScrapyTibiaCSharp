using System;

namespace TibiaApi.Comum.ScrapyModels
{
    public class KillStatScrapy : BasicScrapy
    {
        public string Race { get; set; }
        public int KilledPlayer { get; set; }
        public int KilledByPlayer { get; set; }
        public DateTime RegisterDate { get; set; }
        public long MonsterKillStatId { get; set; }
        public string WorldName { get; set; }
    }
}
