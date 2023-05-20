using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.API.Migrations
{
    /// <inheritdoc />
    public partial class ukonymigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ukons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    VybaveniId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NazevAkce = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ukons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ukons_Vybavenis_VybaveniId",
                        column: x => x.VybaveniId,
                        principalTable: "Vybavenis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ukons_VybaveniId",
                table: "Ukons",
                column: "VybaveniId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ukons");
        }
    }
}
