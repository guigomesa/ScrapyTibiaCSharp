using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TibiaApi.Database.Sql
{
    [Table("kill_stat")]
    public class KillStat : BasicEntity
    {
        [Column("race")]
        public string Race { get; set; }
        [Column("killed_player")]
        public int KilledPlayer { get; set; }
        [Column("killed_by_player")]
        public int KilledByPlayer { get; set; }
        [Required]
        [Column("register_date")]
        public DateTime RegisterDate { get; set; }

        [Column("monster_kill_stats_id")]
        public long MonsterKillStatId { get; set; }
        public MonsterKillStats MonsterKillStat { get; set; }

        [Required]
        [Column("id_world")]
        public long IdWorld { get; set; }

        public World World { get; set; }
    }
}