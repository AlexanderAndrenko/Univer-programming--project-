using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class changecolumnInDishItemFact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DishItemFacts_DishItemFactId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DishItemFactId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DishItemFactId",
                table: "Documents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DishItemFactId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DishItemFactId",
                table: "Documents",
                column: "DishItemFactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DishItemFacts_DishItemFactId",
                table: "Documents",
                column: "DishItemFactId",
                principalTable: "DishItemFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
