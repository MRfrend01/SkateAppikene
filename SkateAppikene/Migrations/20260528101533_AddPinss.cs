using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkateAppikene.Migrations
{
    /// <inheritdoc />
    public partial class AddPinss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pins",
                newName: "Nimi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nimi",
                table: "Pins",
                newName: "Name");
        }

    }

}
