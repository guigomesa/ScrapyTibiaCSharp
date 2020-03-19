﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TibiaApi.Database;

namespace TibiaApi.Database.Migrations
{
    [DbContext(typeof(TibiaDbContext))]
    partial class TibiaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TibiaApi.Database.DeathPlayer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("DescriptionDeath")
                        .HasColumnName("description_death")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("EventDate")
                        .HasColumnName("event_date");

                    b.Property<long>("PlayerId")
                        .HasColumnName("player_id");

                    b.Property<string>("PlayersMurder")
                        .HasColumnName("player_murder");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("death_player");
                });

            modelBuilder.Entity("TibiaApi.Database.KillStat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("IdWorld")
                        .HasColumnName("id_world");

                    b.Property<int>("KilledByPlayer")
                        .HasColumnName("killed_by_player");

                    b.Property<int>("KilledPlayer")
                        .HasColumnName("killed_player");

                    b.Property<long>("MonsterKillStatId")
                        .HasColumnName("monster_kill_stats_id");

                    b.Property<string>("Race")
                        .HasColumnName("race");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("register_date");

                    b.Property<long?>("WorldId");

                    b.HasKey("Id");

                    b.HasIndex("MonsterKillStatId");

                    b.HasIndex("WorldId");

                    b.ToTable("kill_stat");
                });

            modelBuilder.Entity("TibiaApi.Database.MonsterKillStats", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("IdWorld")
                        .HasColumnName("id_world");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("register_date");

                    b.Property<long?>("WorldId");

                    b.HasKey("Id");

                    b.HasIndex("WorldId");

                    b.ToTable("monster_kill_stats");
                });

            modelBuilder.Entity("TibiaApi.Database.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("AccountStatus")
                        .HasColumnName("account_status");

                    b.Property<int>("AchievementPoints")
                        .HasColumnName("achievement_points");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date");

                    b.Property<string>("GuildName")
                        .HasColumnName("guild_name");

                    b.Property<string>("House")
                        .HasColumnName("house");

                    b.Property<long>("IdWorld")
                        .HasColumnName("id_world");

                    b.Property<string>("InfoAccount")
                        .HasColumnName("info_account");

                    b.Property<string>("LastLogin")
                        .IsRequired()
                        .HasColumnName("last_login");

                    b.Property<DateTime>("LastScrapyDate")
                        .HasColumnName("last_scrapy_date");

                    b.Property<int>("Level")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<string>("OlderNames")
                        .HasColumnName("older_names");

                    b.Property<string>("ResidenceCity")
                        .IsRequired()
                        .HasColumnName("residence_player");

                    b.Property<int>("Sex")
                        .HasColumnName("sex");

                    b.Property<long?>("WorldId");

                    b.HasKey("Id");

                    b.HasIndex("WorldId");

                    b.ToTable("player");
                });

            modelBuilder.Entity("TibiaApi.Database.PlayerHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("AccountStatus")
                        .HasColumnName("account_status");

                    b.Property<int>("AchievementPoints")
                        .HasColumnName("achiement_points");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date");

                    b.Property<string>("GuildName")
                        .HasColumnName("guild_name");

                    b.Property<string>("House")
                        .HasColumnName("house");

                    b.Property<long>("IdWorld")
                        .HasColumnName("id_world");

                    b.Property<string>("InfoAccount")
                        .HasColumnName("info_account");

                    b.Property<string>("LastLogin")
                        .HasColumnName("last_login");

                    b.Property<DateTime>("LastScrapyDate")
                        .HasColumnName("last_scrapy_date");

                    b.Property<int>("Level")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<string>("OlderNames")
                        .HasColumnName("older_names");

                    b.Property<long>("PlayerId")
                        .HasColumnName("player_id");

                    b.Property<string>("ResidenceCity")
                        .IsRequired()
                        .HasColumnName("residence_city");

                    b.Property<int>("Sex")
                        .HasColumnName("sex");

                    b.Property<long?>("WorldId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("WorldId");

                    b.ToTable("player_history");
                });

            modelBuilder.Entity("TibiaApi.Database.Stats", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("register_date");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<int>("TotalPlayerOnline")
                        .HasColumnName("total_player_online");

                    b.Property<long>("WorldId")
                        .HasColumnName("world_id");

                    b.HasKey("Id");

                    b.HasIndex("WorldId");

                    b.ToTable("stats");
                });

            modelBuilder.Entity("TibiaApi.Database.World", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<int>("PvpType")
                        .HasColumnName("pvp_type");

                    b.Property<DateTime>("ScrapyData")
                        .HasColumnName("scrapy_data");

                    b.HasKey("Id");

                    b.ToTable("world");
                });

            modelBuilder.Entity("TibiaApi.Database.DeathPlayer", b =>
                {
                    b.HasOne("TibiaApi.Database.Player", "Player")
                        .WithMany("Deaths")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TibiaApi.Database.KillStat", b =>
                {
                    b.HasOne("TibiaApi.Database.MonsterKillStats", "MonsterKillStat")
                        .WithMany("KillStats")
                        .HasForeignKey("MonsterKillStatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TibiaApi.Database.World", "World")
                        .WithMany()
                        .HasForeignKey("WorldId");
                });

            modelBuilder.Entity("TibiaApi.Database.MonsterKillStats", b =>
                {
                    b.HasOne("TibiaApi.Database.World", "World")
                        .WithMany()
                        .HasForeignKey("WorldId");
                });

            modelBuilder.Entity("TibiaApi.Database.Player", b =>
                {
                    b.HasOne("TibiaApi.Database.World", "World")
                        .WithMany("Players")
                        .HasForeignKey("WorldId");
                });

            modelBuilder.Entity("TibiaApi.Database.PlayerHistory", b =>
                {
                    b.HasOne("TibiaApi.Database.Player", "Player")
                        .WithMany("History")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TibiaApi.Database.World", "World")
                        .WithMany()
                        .HasForeignKey("WorldId");
                });

            modelBuilder.Entity("TibiaApi.Database.Stats", b =>
                {
                    b.HasOne("TibiaApi.Database.World", "World")
                        .WithMany("Statistics")
                        .HasForeignKey("WorldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
