using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkateAppikene.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Eesnimi = table.Column<string>(type: "TEXT", nullable: false),
                    Perenimi = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Kasutajanimi = table.Column<string>(type: "TEXT", nullable: false),
                    ParoolHash = table.Column<string>(type: "TEXT", nullable: false),
                    Tase = table.Column<string>(type: "TEXT", nullable: false),
                    LoodudKuupäev = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
