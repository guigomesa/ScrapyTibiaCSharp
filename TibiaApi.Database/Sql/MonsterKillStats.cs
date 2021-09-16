using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TibiaApi.Database.Sql
{
    [Table("monster_kill_stats")]
    public class MonsterKillStats : BasicEntity
    {
        [Required]
        [Column("register_date")]
        public DateTime RegisterDate { get; set; }
        [Required]
        [Column("id_world")]
        public long IdWorld { get; set; }
        public virtual World World { get; set; }

        public List<KillStat> KillStats { get; set; } = new List<KillStat>();
    }
}