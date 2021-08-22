using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class ChangedTypeOfVar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_MenuFacts_MenuFactId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_MenuFactId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "MenuFactId",
                table: "Dishes");

            migrationBuilder.AlterColumn<float>(
                name: "YardNorm",
                table: "DishItems",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "NurseryNorm",
                table: "DishItems",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "YardNorm",
                table: "DishItemFacts",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "NurseryNorm",
                table: "DishItemFacts",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YardNorm",
                table: "DishItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "NurseryNorm",
                table: "DishItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "YardNorm",
                table: "DishItemFacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "NurseryNorm",
                table: "DishItemFacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "MenuFactId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MenuFactId",
                table: "Dishes",
                column: "MenuFactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_MenuFacts_MenuFactId",
                table: "Dishes",
                column: "MenuFactId",
                principalTable: "MenuFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
