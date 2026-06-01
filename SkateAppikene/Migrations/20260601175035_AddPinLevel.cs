using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkateAppikene.Migrations
{
    /// <inheritdoc />
    public partial class AddPinLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tase",
                table: "Pins",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tase",
                table: "Pins");
        }
    }
}
