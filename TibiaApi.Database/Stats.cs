using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TibiaApi.Comum.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace TibiaApi.Database
{
    [Table("stats")]
    public class Stats : BasicEntity
    {
        [Required]
        [Column("register_date")]
        public DateTime RegisterDate { get; set; }
        [Required]
        [Column("total_player_online")]
        public int TotalPlayerOnline { get; set; }
        [Required]
        [Column("status")]
        public StatusWorld Status { get; set; }
        [Required]
        [Column("world_id")]
        public long WorldId { get; set; }
        public virtual World World { get; set; }
    }
}