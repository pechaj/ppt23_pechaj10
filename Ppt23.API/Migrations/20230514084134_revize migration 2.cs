using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.API.Migrations
{
    /// <inheritdoc />
    public partial class revizemigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Revizes",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Revizes",
                newName: "NAME");
        }
    }
}
