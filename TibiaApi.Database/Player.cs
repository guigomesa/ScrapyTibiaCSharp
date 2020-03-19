using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TibiaApi.Comum.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using TibiaApi.Comum.ScrapyModels;

namespace TibiaApi.Database
{
    [Table("player")]
    public class Player : BasicEntity
    {
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("older_names")]
        public string OlderNames { get; set; }
        [Required]
        [Column("sex")]
        public Sex Sex { get; set; }
        [Required]
        [Column("level")]
        public int Level { get; set; }
        [Column("achievement_points")]
        public int AchievementPoints { get; set; }
        [Required]
        [Column("residence_player")]
        public string ResidenceCity { get; set; }
        [Column("house")]
        public string House { get; set; }
        [Column("guild_name")]
        public string GuildName { get; set; }
        [Required]
        [Column("last_login")]
        public string LastLogin { get; set; }
        [Column("account_status")]
        public string AccountStatus { get; set; }
        [Column("info_account")]
        public string InfoAccount { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        [Column("last_scrapy_date")]
        [Required]
        public DateTime LastScrapyDate { get; set; } = DateTime.Now;
        [Required]
        [Column("id_world")]
        public long IdWorld { get; set; }
        public World World { get; set; }
        
        public List<DeathPlayer> Deaths { get; set; } = new List<DeathPlayer>();
        public List<PlayerHistory> History { get; set; } = new List<PlayerHistory>();

        public Player UpdatePlayer(Player novoPlayer)
        {
            this.Name = novoPlayer.Name;
            this.OlderNames = novoPlayer.OlderNames;
            this.Sex = novoPlayer.Sex;
            this.Level = novoPlayer.Level;
            this.AchievementPoints = novoPlayer.AchievementPoints;
            this.ResidenceCity = novoPlayer.ResidenceCity;
            this.House = novoPlayer.House;
            this.GuildName = novoPlayer.GuildName;
            this.LastLogin = novoPlayer.LastLogin;
            this.AccountStatus = novoPlayer.AccountStatus;
            this.InfoAccount = novoPlayer.InfoAccount;
            this.CreationDate = novoPlayer.CreationDate;
            LastScrapyDate = DateTime.Now;

            return this;
        }

        public Player UpdateWorld(World world)
        {
            this.IdWorld = world.Id;
            this.World = world;
            return this;
        }

        public Player AddDeath(DeathPlayer[] deaths)
        {
            foreach(var death in deaths)
            {
                death.PlayerId = this.Id;
                death.Player = this;

                this.Deaths.Add(death);
            }

            return this;
        }

        public Player AddNewHistoryScrapy(Player player, World world)
        {
            var history = new PlayerHistory
            { 
                Name=player.Name,
                OlderNames= player.OlderNames,
                Sex = player.Sex,
                Level = player.Level,
                AchievementPoints = player.AchievementPoints,
                ResidenceCity = player.ResidenceCity,
                House = player.House,
                GuildName = player.GuildName,
                InfoAccount = player.InfoAccount,
                CreationDate = player.CreationDate,
                LastLogin = player.LastLogin,
                LastScrapyDate = player.LastScrapyDate,
                IdWorld = world.Id,
                PlayerId = player.Id,
                World = world,
                Player = player                
            }; 

            History.Add(history);

            return this;
        }
    }
}