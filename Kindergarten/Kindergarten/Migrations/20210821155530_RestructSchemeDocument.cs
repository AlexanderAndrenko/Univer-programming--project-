using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class RestructSchemeDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Invoices_InvoiceId",
                table: "Parties");

            migrationBuilder.DropTable(
                name: "MovingProducts");

            migrationBuilder.DropTable(
                name: "TypeMovingProducts");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Parties",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_InvoiceId",
                table: "Parties",
                newName: "IX_Parties_DocumentId");

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    DishItemFatcId = table.Column<int>(type: "int", nullable: true),
                    DishItemFactId = table.Column<int>(type: "int", nullable: true),
                    NumberChildrenId = table.Column<int>(type: "int", nullable: true),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DishItemFacts_DishItemFactId",
                        column: x => x.DishItemFactId,
                        principalTable: "DishItemFacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Documents_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Documents_NumberChildrens_NumberChildrenId",
                        column: x => x.NumberChildrenId,
                        principalTable: "NumberChildrens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DocumentData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentData_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocumentData_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocumentData_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentData_DocumentId",
                table: "DocumentData",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentData_PartyId",
                table: "DocumentData",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentData_ProductId",
                table: "DocumentData",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Date",
                table: "Documents",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DishItemFactId",
                table: "Documents",
                column: "DishItemFactId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_InvoiceId",
                table: "Documents",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_NumberChildrenId",
                table: "Documents",
                column: "NumberChildrenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Documents_DocumentId",
                table: "Parties",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Documents_DocumentId",
                table: "Parties");

            migrationBuilder.DropTable(
                name: "DocumentData");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Parties",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_DocumentId",
                table: "Parties",
                newName: "IX_Parties_InvoiceId");

            migrationBuilder.CreateTable(
                name: "TypeMovingProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMovingProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovingProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    DishItemFactId = table.Column<int>(type: "int", nullable: true),
                    DishItemFatcId = table.Column<int>(type: "int", nullable: false),
                    NumberChildrenId = table.Column<int>(type: "int", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    TypeMovingProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovingProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovingProducts_DishItemFacts_DishItemFactId",
                        column: x => x.DishItemFactId,
                        principalTable: "DishItemFacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovingProducts_NumberChildrens_NumberChildrenId",
                        column: x => x.NumberChildrenId,
                        principalTable: "NumberChildrens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovingProducts_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovingProducts_TypeMovingProducts_TypeMovingProductId",
                        column: x => x.TypeMovingProductId,
                        principalTable: "TypeMovingProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovingProducts_Date",
                table: "MovingProducts",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_MovingProducts_DishItemFactId",
                table: "MovingProducts",
                column: "DishItemFactId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingProducts_NumberChildrenId",
                table: "MovingProducts",
                column: "NumberChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingProducts_PartyId",
                table: "MovingProducts",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingProducts_TypeMovingProductId",
                table: "MovingProducts",
                column: "TypeMovingProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Invoices_InvoiceId",
                table: "Parties",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
