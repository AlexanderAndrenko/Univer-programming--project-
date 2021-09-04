using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class changefieldsinDocumentDataDishItemFact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentData_DishFacts_DishFactId",
                table: "DocumentData");

            migrationBuilder.DropIndex(
                name: "IX_DocumentData_DishFactId",
                table: "DocumentData");

            migrationBuilder.DropColumn(
                name: "DishFactId",
                table: "DocumentData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DishFactId",
                table: "DocumentData",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentData_DishFactId",
                table: "DocumentData",
                column: "DishFactId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentData_DishFacts_DishFactId",
                table: "DocumentData",
                column: "DishFactId",
                principalTable: "DishFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
