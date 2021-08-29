using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class ChangeFieldsInDocumentsAndDocumentDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DishItemFatcId",
                table: "Documents",
                newName: "MenuFactId");

            migrationBuilder.AddColumn<int>(
                name: "DishFactId",
                table: "DocumentData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DishItemFactId",
                table: "DocumentData",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_MenuFactId",
                table: "Documents",
                column: "MenuFactId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentData_DishFactId",
                table: "DocumentData",
                column: "DishFactId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentData_DishItemFactId",
                table: "DocumentData",
                column: "DishItemFactId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentData_DishFacts_DishFactId",
                table: "DocumentData",
                column: "DishFactId",
                principalTable: "DishFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentData_DishItemFacts_DishItemFactId",
                table: "DocumentData",
                column: "DishItemFactId",
                principalTable: "DishItemFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_MenuFacts_MenuFactId",
                table: "Documents",
                column: "MenuFactId",
                principalTable: "MenuFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentData_DishFacts_DishFactId",
                table: "DocumentData");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentData_DishItemFacts_DishItemFactId",
                table: "DocumentData");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_MenuFacts_MenuFactId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_MenuFactId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_DocumentData_DishFactId",
                table: "DocumentData");

            migrationBuilder.DropIndex(
                name: "IX_DocumentData_DishItemFactId",
                table: "DocumentData");

            migrationBuilder.DropColumn(
                name: "DishFactId",
                table: "DocumentData");

            migrationBuilder.DropColumn(
                name: "DishItemFactId",
                table: "DocumentData");

            migrationBuilder.RenameColumn(
                name: "MenuFactId",
                table: "Documents",
                newName: "DishItemFatcId");
        }
    }
}
