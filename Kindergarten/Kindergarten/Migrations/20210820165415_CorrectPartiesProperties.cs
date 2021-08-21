using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class CorrectPartiesProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Suppliers_SupplierId",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "SuppleirId",
                table: "Parties");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Parties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Suppliers_SupplierId",
                table: "Parties",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Suppliers_SupplierId",
                table: "Parties");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Parties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SuppleirId",
                table: "Parties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Suppliers_SupplierId",
                table: "Parties",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
