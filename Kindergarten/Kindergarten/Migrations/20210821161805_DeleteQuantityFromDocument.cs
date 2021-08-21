using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class DeleteQuantityFromDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Documents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "Documents",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
