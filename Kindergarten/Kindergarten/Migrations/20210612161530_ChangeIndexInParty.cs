using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class ChangeIndexInParty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Party_DateCreated_IsClosed",
                table: "Party");

            migrationBuilder.CreateIndex(
                name: "IX_Party_DateCreated",
                table: "Party",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_Party_IsClosed",
                table: "Party",
                column: "IsClosed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Party_DateCreated",
                table: "Party");

            migrationBuilder.DropIndex(
                name: "IX_Party_IsClosed",
                table: "Party");

            migrationBuilder.CreateIndex(
                name: "IX_Party_DateCreated_IsClosed",
                table: "Party",
                columns: new[] { "DateCreated", "IsClosed" });
        }
    }
}
