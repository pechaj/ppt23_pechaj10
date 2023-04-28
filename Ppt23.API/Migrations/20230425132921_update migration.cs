using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.API.Migrations
{
    /// <inheritdoc />
    public partial class updatemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vybavenis",
                newName: "NAME");

            migrationBuilder.AddColumn<int>(
                name: "CENA",
                table: "Vybavenis",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATEBUY",
                table: "Vybavenis",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LASTREV",
                table: "Vybavenis",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CENA",
                table: "Vybavenis");

            migrationBuilder.DropColumn(
                name: "DATEBUY",
                table: "Vybavenis");

            migrationBuilder.DropColumn(
                name: "LASTREV",
                table: "Vybavenis");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Vybavenis",
                newName: "Name");
        }
    }
}
