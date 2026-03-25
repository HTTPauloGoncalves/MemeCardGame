using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemeCardGame.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    meme_description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    followers_cost = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    defense = table.Column<int>(type: "integer", nullable: false),
                    attack = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "character varying(600)", maxLength: 600, nullable: false),
                    rarity = table.Column<int>(type: "integer", nullable: false),
                    effect = table.Column<string>(type: "text", nullable: false),
                    meme_phrase = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "matchs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_one_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_two_id = table.Column<Guid>(type: "uuid", nullable: false),
                    winner = table.Column<Guid>(type: "uuid", nullable: false),
                    player_one_hp = table.Column<int>(type: "integer", nullable: false),
                    player_two_hp = table.Column<int>(type: "integer", nullable: false),
                    total_turns = table.Column<int>(type: "integer", nullable: false),
                    finished_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    started_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_matchs", x => x.id);
                    table.ForeignKey(
                        name: "fk_matchs_users_player_one_id",
                        column: x => x.player_one_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_matchs_users_player_two_id",
                        column: x => x.player_two_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_matchs_player_one_id",
                table: "matchs",
                column: "player_one_id");

            migrationBuilder.CreateIndex(
                name: "ix_matchs_player_two_id",
                table: "matchs",
                column: "player_two_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.DropTable(
                name: "matchs");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
