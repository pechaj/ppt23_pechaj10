using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.API.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Vybavenis",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CENA",
                table: "Vybavenis",
                newName: "Cena");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vybavenis",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Cena",
                table: "Vybavenis",
                newName: "CENA");
        }
    }
}
