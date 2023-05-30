using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppt23.API.Migrations
{
    /// <inheritdoc />
    public partial class pracovnikmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ukons_PracovnikId",
                table: "Ukons",
                column: "PracovnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ukons_Pracovniks_PracovnikId",
                table: "Ukons",
                column: "PracovnikId",
                principalTable: "Pracovniks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ukons_Pracovniks_PracovnikId",
                table: "Ukons");

            migrationBuilder.DropIndex(
                name: "IX_Ukons_PracovnikId",
                table: "Ukons");
        }
    }
}
