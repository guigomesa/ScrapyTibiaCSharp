using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TibiaApi.Comum.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace TibiaApi.Database
{
    [Table("world")]
    public class World : BasicEntity
    {   
        public World()
        {
            Players = new List<Player>();
            Statistics = new List<Stats>();
        }
        
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("location")]
        public string Location { get; set; }
        [Required]
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        [Required]
        [Column("pvp_type")]
        public PvpType PvpType { get; set; } 
        [Column("scrapy_data")]
        public DateTime ScrapyData {get;set;} = DateTime.Now;
        public virtual List<Player> Players { get; set; }
        public virtual List<Stats> Statistics { get; set; }
        
        
        
    }
}