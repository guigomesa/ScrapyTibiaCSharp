using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TibiaApi.Database.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "world",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    location = table.Column<string>(nullable: false),
                    creation_date = table.Column<DateTime>(nullable: false),
                    pvp_type = table.Column<int>(nullable: false),
                    scrapy_data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_world", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "monster_kill_stats",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    register_date = table.Column<DateTime>(nullable: false),
                    id_world = table.Column<long>(nullable: false),
                    WorldId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monster_kill_stats", x => x.id);
                    table.ForeignKey(
                        name: "FK_monster_kill_stats_world_WorldId",
                        column: x => x.WorldId,
                        principalTable: "world",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    older_names = table.Column<string>(nullable: true),
                    sex = table.Column<int>(nullable: false),
                    level = table.Column<int>(nullable: false),
                    achievement_points = table.Column<int>(nullable: false),
                    residence_player = table.Column<string>(nullable: false),
                    house = table.Column<string>(nullable: true),
                    guild_name = table.Column<string>(nullable: true),
                    last_login = table.Column<string>(nullable: false),
                    account_status = table.Column<string>(nullable: true),
                    info_account = table.Column<string>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: false),
                    last_scrapy_date = table.Column<DateTime>(nullable: false),
                    id_world = table.Column<long>(nullable: false),
                    WorldId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.id);
                    table.ForeignKey(
                        name: "FK_player_world_WorldId",
                        column: x => x.WorldId,
                        principalTable: "world",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stats",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    register_date = table.Column<DateTime>(nullable: false),
                    total_player_online = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    world_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stats", x => x.id);
                    table.ForeignKey(
                        name: "FK_stats_world_world_id",
                        column: x => x.world_id,
                        principalTable: "world",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kill_stat",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    race = table.Column<string>(nullable: true),
                    killed_player = table.Column<int>(nullable: false),
                    killed_by_player = table.Column<int>(nullable: false),
                    register_date = table.Column<DateTime>(nullable: false),
                    monster_kill_stats_id = table.Column<long>(nullable: false),
                    id_world = table.Column<long>(nullable: false),
                    WorldId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kill_stat", x => x.id);
                    table.ForeignKey(
                        name: "FK_kill_stat_monster_kill_stats_monster_kill_stats_id",
                        column: x => x.monster_kill_stats_id,
                        principalTable: "monster_kill_stats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kill_stat_world_WorldId",
                        column: x => x.WorldId,
                        principalTable: "world",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "death_player",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    description_death = table.Column<string>(maxLength: 1000, nullable: true),
                    event_date = table.Column<DateTime>(nullable: false),
                    player_murder = table.Column<string>(nullable: true),
                    player_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_death_player", x => x.id);
                    table.ForeignKey(
                        name: "FK_death_player_player_player_id",
                        column: x => x.player_id,
                        principalTable: "player",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_history",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    older_names = table.Column<string>(nullable: true),
                    sex = table.Column<int>(nullable: false),
                    level = table.Column<int>(nullable: false),
                    achiement_points = table.Column<int>(nullable: false),
                    residence_city = table.Column<string>(nullable: false),
                    house = table.Column<string>(nullable: true),
                    guild_name = table.Column<string>(nullable: true),
                    last_login = table.Column<string>(nullable: true),
                    account_status = table.Column<string>(nullable: true),
                    info_account = table.Column<string>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: false),
                    last_scrapy_date = table.Column<DateTime>(nullable: false),
                    id_world = table.Column<long>(nullable: false),
                    WorldId = table.Column<long>(nullable: true),
                    player_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_player_history_player_player_id",
                        column: x => x.player_id,
                        principalTable: "player",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_player_history_world_WorldId",
                        column: x => x.WorldId,
                        principalTable: "world",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_death_player_player_id",
                table: "death_player",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_kill_stat_monster_kill_stats_id",
                table: "kill_stat",
                column: "monster_kill_stats_id");

            migrationBuilder.CreateIndex(
                name: "IX_kill_stat_WorldId",
                table: "kill_stat",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_monster_kill_stats_WorldId",
                table: "monster_kill_stats",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_player_WorldId",
                table: "player",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_player_history_player_id",
                table: "player_history",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_history_WorldId",
                table: "player_history",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_stats_world_id",
                table: "stats",
                column: "world_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "death_player");

            migrationBuilder.DropTable(
                name: "kill_stat");

            migrationBuilder.DropTable(
                name: "player_history");

            migrationBuilder.DropTable(
                name: "stats");

            migrationBuilder.DropTable(
                name: "monster_kill_stats");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "world");
        }
    }
}
