using System;
using AutoMapper;
using TibiaApi.Comum.ScrapyModels;
using TibiaApi.Comum.WebReturns;
using TibiaApi.Database;
using TibiaApi.Repository;

namespace TibiaApi.Service
{
    public class KillStatsService<IKillStatRepository> : BasicService<IKillStatsRepository<KillStat>, KillStat>, IKillStatsService<IKillStatRepository>
    {
        public KillStatsService(IKillStatsRepository<KillStat> repository) : base(repository) { }

        public override ModelBaseReturn SaveFromScrapy<KillStatScrapy>(KillStatScrapy model)
        {
            return null;
        }
    }
}