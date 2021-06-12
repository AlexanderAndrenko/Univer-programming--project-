using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class CreateAllEntityOfModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuFactId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MenuFact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuFact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumberChildren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    QuantityNursery = table.Column<int>(type: "int", nullable: false),
                    QuantityYard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberChildren", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeMovingProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMovingProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LevelAccess = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishFact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DishNurseryNorm = table.Column<int>(type: "int", nullable: false),
                    DishYardNorm = table.Column<int>(type: "int", nullable: false),
                    MenuFactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishFact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishFact_MenuFact_MenuFactId",
                        column: x => x.MenuFactId,
                        principalTable: "MenuFact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoice_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishItemFact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseryNorm = table.Column<int>(type: "int", nullable: false),
                    YardNorm = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DishFactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishItemFact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishItemFact_DishFact_DishFactId",
                        column: x => x.DishFactId,
                        principalTable: "DishFact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishItemFact_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateClosed = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SuppleirId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Party", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Party_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Party_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Party_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovingProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    DishItemFatcId = table.Column<int>(type: "int", nullable: false),
                    DishItemFactId = table.Column<int>(type: "int", nullable: true),
                    NumberChildrenId = table.Column<int>(type: "int", nullable: false),
                    TypeMovingProductId = table.Column<int>(type: "int", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovingProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovingProduct_DishItemFact_DishItemFactId",
                        column: x => x.DishItemFactId,
                        principalTable: "DishItemFact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovingProduct_NumberChildren_NumberChildrenId",
                        column: x => x.NumberChildrenId,
                        principalTable: "NumberChildren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovingProduct_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovingProduct_TypeMovingProduct_TypeMovingProductId",
                        column: x => x.TypeMovingProductId,
                        principalTable: "TypeMovingProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MenuFactId",
                table: "Dishes",
                column: "MenuFactId");

            migrationBuilder.CreateIndex(
                name: "IX_DishFact_MenuFactId",
                table: "DishFact",
                column: "MenuFactId");

            migrationBuilder.CreateIndex(
                name: "IX_DishItemFact_DishFactId",
                table: "DishItemFact",
                column: "DishFactId");

            migrationBuilder.CreateIndex(
                name: "IX_DishItemFact_ProductId",
                table: "DishItemFact",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SupplierId",
                table: "Invoice",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingProduct_Date",
                table: "MovingProduct",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_MovingProduct_DishItemFactId",
                table: "MovingProduct",
                column: "DishItemFactId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingProduct_NumberChildrenId",
                table: "MovingProduct",
                column: "NumberChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingProduct_PartyId",
                table: "MovingProduct",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingProduct_TypeMovingProductId",
                table: "MovingProduct",
                column: "TypeMovingProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Party_DateCreated_IsClosed",
                table: "Party",
                columns: new[] { "DateCreated", "IsClosed" });

            migrationBuilder.CreateIndex(
                name: "IX_Party_InvoiceId",
                table: "Party",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Party_ProductId",
                table: "Party",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Party_SupplierId",
                table: "Party",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_MenuFact_MenuFactId",
                table: "Dishes",
                column: "MenuFactId",
                principalTable: "MenuFact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_MenuFact_MenuFactId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "MovingProduct");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "DishItemFact");

            migrationBuilder.DropTable(
                name: "NumberChildren");

            migrationBuilder.DropTable(
                name: "Party");

            migrationBuilder.DropTable(
                name: "TypeMovingProduct");

            migrationBuilder.DropTable(
                name: "DishFact");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "MenuFact");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_MenuFactId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "MenuFactId",
                table: "Dishes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");
        }
    }
}
