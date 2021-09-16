using Microsoft.EntityFrameworkCore;

namespace TibiaApi.Database.Sql
{
    public class TibiaDbContext : DbContext
    {
        public DbSet<DeathPlayer> DeathPlayers { get; set; }
        public DbSet<KillStat> KillStats { get; set; }
        public DbSet<MonsterKillStats> MonsterKillStatses { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerHistory> PlayerHistories { get; set; }
        public DbSet<Stats> Statses { get; set; }
        public DbSet<World> Worlds { get; set; }

        public TibiaDbContext(DbContextOptions<TibiaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}