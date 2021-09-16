using System;
using System.ComponentModel.DataAnnotations;
using TibiaApi.Comum.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace TibiaApi.Database.Sql
{
    [Table("player_history")]
    public class PlayerHistory : BasicEntity
    {
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("older_names")]
        public string OlderNames { get; set; }
        [Column("sex")]
        [Required]
        public Sex Sex { get; set; }
        [Required]
        [Column("level")]
        public int Level { get; set; }
        [Column("achiement_points")]
        public int AchievementPoints { get; set; }
        [Required]
        [Column("residence_city")]
        public string ResidenceCity { get; set; }
        [Column("house")]
        public string House { get; set; }
        [Column("guild_name")]
        public string GuildName { get; set; }
        [Column("last_login")]
        public string LastLogin { get; set; }
        [Column("account_status")]
        public string AccountStatus { get; set; }
        [Column("info_account")]
        public string InfoAccount { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        [Required]
        [Column("last_scrapy_date")]
        public DateTime LastScrapyDate { get; set; }
        [Required]
        [Column("id_world")]
        public long IdWorld { get; set; }
        public World World { get; set; }
        [Required]
        [Column("player_id")]
        public long PlayerId { get; set; }
        public Player Player { get; set; }
    }
}