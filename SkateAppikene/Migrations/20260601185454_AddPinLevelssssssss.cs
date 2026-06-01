using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkateAppikene.Migrations
{
    /// <inheritdoc />
    public partial class AddPinLevelssssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pins",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pins");
        }
    }
}
