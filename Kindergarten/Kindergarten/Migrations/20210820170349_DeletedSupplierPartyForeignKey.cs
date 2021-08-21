using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class DeletedSupplierPartyForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Suppliers_SupplierId",
                table: "Parties");

            migrationBuilder.DropIndex(
                name: "IX_Parties_SupplierId",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Parties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Parties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parties_SupplierId",
                table: "Parties",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Suppliers_SupplierId",
                table: "Parties",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
