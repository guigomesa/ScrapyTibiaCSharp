using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TibiaApi.Database.Sql
{
    [Table("death_player")]
    public class DeathPlayer : BasicEntity
    {        
        [MaxLength(1000)]
        [Column("description_death")]
        public string DescriptionDeath { get; set; }
        [Required]
        [Column("event_date")]
        public DateTime EventDate { get; set; }
        [Column("player_murder")]
        public string PlayersMurder { get; set; }
        
        
        [Required]
        [Column("player_id")]
        public long PlayerId { get; set; }
        public Player Player { get; set; }
    }
}