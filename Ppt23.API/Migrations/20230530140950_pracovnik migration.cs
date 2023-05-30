using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.API.Migrations
{
    /// <inheritdoc />
    public partial class pracovnikmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PracovnikId",
                table: "Ukons",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pracovniks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Jmeno = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracovniks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pracovniks");

            migrationBuilder.DropColumn(
                name: "PracovnikId",
                table: "Ukons");
        }
    }
}
