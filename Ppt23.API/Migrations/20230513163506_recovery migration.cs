using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.API.Migrations
{
    /// <inheritdoc />
    public partial class recoverymigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vybavenis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NAME = table.Column<string>(type: "TEXT", nullable: false),
                    DATEBUY = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CENA = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vybavenis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    VybaveniId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NAME = table.Column<string>(type: "TEXT", nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revizes_Vybavenis_VybaveniId",
                        column: x => x.VybaveniId,
                        principalTable: "Vybavenis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revizes_VybaveniId",
                table: "Revizes",
                column: "VybaveniId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revizes");

            migrationBuilder.DropTable(
                name: "Vybavenis");
        }
    }
}
