using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarten.Migrations
{
    public partial class AddedDbSetInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_MenuFact_MenuFactId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishFact_MenuFact_MenuFactId",
                table: "DishFact");

            migrationBuilder.DropForeignKey(
                name: "FK_DishItemFact_DishFact_DishFactId",
                table: "DishItemFact");

            migrationBuilder.DropForeignKey(
                name: "FK_DishItemFact_Products_ProductId",
                table: "DishItemFact");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Supplier_SupplierId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_MovingProduct_DishItemFact_DishItemFactId",
                table: "MovingProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_MovingProduct_NumberChildren_NumberChildrenId",
                table: "MovingProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_MovingProduct_Party_PartyId",
                table: "MovingProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_MovingProduct_TypeMovingProduct_TypeMovingProductId",
                table: "MovingProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Party_Invoice_InvoiceId",
                table: "Party");

            migrationBuilder.DropForeignKey(
                name: "FK_Party_Products_ProductId",
                table: "Party");

            migrationBuilder.DropForeignKey(
                name: "FK_Party_Supplier_SupplierId",
                table: "Party");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeMovingProduct",
                table: "TypeMovingProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Party",
                table: "Party");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NumberChildren",
                table: "NumberChildren");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovingProduct",
                table: "MovingProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuFact",
                table: "MenuFact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishItemFact",
                table: "DishItemFact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishFact",
                table: "DishFact");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TypeMovingProduct",
                newName: "TypeMovingProducts");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Party",
                newName: "Parties");

            migrationBuilder.RenameTable(
                name: "NumberChildren",
                newName: "NumberChildrens");

            migrationBuilder.RenameTable(
                name: "MovingProduct",
                newName: "MovingProducts");

            migrationBuilder.RenameTable(
                name: "MenuFact",
                newName: "MenuFacts");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "DishItemFact",
                newName: "DishItemFacts");

            migrationBuilder.RenameTable(
                name: "DishFact",
                newName: "DishFacts");

            migrationBuilder.RenameIndex(
                name: "IX_Party_SupplierId",
                table: "Parties",
                newName: "IX_Parties_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Party_ProductId",
                table: "Parties",
                newName: "IX_Parties_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Party_IsClosed",
                table: "Parties",
                newName: "IX_Parties_IsClosed");

            migrationBuilder.RenameIndex(
                name: "IX_Party_InvoiceId",
                table: "Parties",
                newName: "IX_Parties_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Party_DateCreated",
                table: "Parties",
                newName: "IX_Parties_DateCreated");

            migrationBuilder.RenameIndex(
                name: "IX_MovingProduct_TypeMovingProductId",
                table: "MovingProducts",
                newName: "IX_MovingProducts_TypeMovingProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MovingProduct_PartyId",
                table: "MovingProducts",
                newName: "IX_MovingProducts_PartyId");

            migrationBuilder.RenameIndex(
                name: "IX_MovingProduct_NumberChildrenId",
                table: "MovingProducts",
                newName: "IX_MovingProducts_NumberChildrenId");

            migrationBuilder.RenameIndex(
                name: "IX_MovingProduct_DishItemFactId",
                table: "MovingProducts",
                newName: "IX_MovingProducts_DishItemFactId");

            migrationBuilder.RenameIndex(
                name: "IX_MovingProduct_Date",
                table: "MovingProducts",
                newName: "IX_MovingProducts_Date");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_SupplierId",
                table: "Invoices",
                newName: "IX_Invoices_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_DishItemFact_ProductId",
                table: "DishItemFacts",
                newName: "IX_DishItemFacts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DishItemFact_DishFactId",
                table: "DishItemFacts",
                newName: "IX_DishItemFacts_DishFactId");

            migrationBuilder.RenameIndex(
                name: "IX_DishFact_MenuFactId",
                table: "DishFacts",
                newName: "IX_DishFacts_MenuFactId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeMovingProducts",
                table: "TypeMovingProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parties",
                table: "Parties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumberChildrens",
                table: "NumberChildrens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovingProducts",
                table: "MovingProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuFacts",
                table: "MenuFacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishItemFacts",
                table: "DishItemFacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishFacts",
                table: "DishFacts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_MenuFacts_MenuFactId",
                table: "Dishes",
                column: "MenuFactId",
                principalTable: "MenuFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishFacts_MenuFacts_MenuFactId",
                table: "DishFacts",
                column: "MenuFactId",
                principalTable: "MenuFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishItemFacts_DishFacts_DishFactId",
                table: "DishItemFacts",
                column: "DishFactId",
                principalTable: "DishFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishItemFacts_Products_ProductId",
                table: "DishItemFacts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Suppliers_SupplierId",
                table: "Invoices",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovingProducts_DishItemFacts_DishItemFactId",
                table: "MovingProducts",
                column: "DishItemFactId",
                principalTable: "DishItemFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovingProducts_NumberChildrens_NumberChildrenId",
                table: "MovingProducts",
                column: "NumberChildrenId",
                principalTable: "NumberChildrens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovingProducts_Parties_PartyId",
                table: "MovingProducts",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovingProducts_TypeMovingProducts_TypeMovingProductId",
                table: "MovingProducts",
                column: "TypeMovingProductId",
                principalTable: "TypeMovingProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Invoices_InvoiceId",
                table: "Parties",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Products_ProductId",
                table: "Parties",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Suppliers_SupplierId",
                table: "Parties",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_MenuFacts_MenuFactId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishFacts_MenuFacts_MenuFactId",
                table: "DishFacts");

            migrationBuilder.DropForeignKey(
                name: "FK_DishItemFacts_DishFacts_DishFactId",
                table: "DishItemFacts");

            migrationBuilder.DropForeignKey(
                name: "FK_DishItemFacts_Products_ProductId",
                table: "DishItemFacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Suppliers_SupplierId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_MovingProducts_DishItemFacts_DishItemFactId",
                table: "MovingProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_MovingProducts_NumberChildrens_NumberChildrenId",
                table: "MovingProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_MovingProducts_Parties_PartyId",
                table: "MovingProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_MovingProducts_TypeMovingProducts_TypeMovingProductId",
                table: "MovingProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Invoices_InvoiceId",
                table: "Parties");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Products_ProductId",
                table: "Parties");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Suppliers_SupplierId",
                table: "Parties");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeMovingProducts",
                table: "TypeMovingProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parties",
                table: "Parties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NumberChildrens",
                table: "NumberChildrens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovingProducts",
                table: "MovingProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuFacts",
                table: "MenuFacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishItemFacts",
                table: "DishItemFacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishFacts",
                table: "DishFacts");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "TypeMovingProducts",
                newName: "TypeMovingProduct");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "Parties",
                newName: "Party");

            migrationBuilder.RenameTable(
                name: "NumberChildrens",
                newName: "NumberChildren");

            migrationBuilder.RenameTable(
                name: "MovingProducts",
                newName: "MovingProduct");

            migrationBuilder.RenameTable(
                name: "MenuFacts",
                newName: "MenuFact");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "DishItemFacts",
                newName: "DishItemFact");

            migrationBuilder.RenameTable(
                name: "DishFacts",
                newName: "DishFact");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_SupplierId",
                table: "Party",
                newName: "IX_Party_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_ProductId",
                table: "Party",
                newName: "IX_Party_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_IsClosed",
                table: "Party",
                newName: "IX_Party_IsClosed");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_InvoiceId",
                table: "Party",
                newName: "IX_Party_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_DateCreated",
                table: "Party",
                newName: "IX_Party_DateCreated");

            migrationBuilder.RenameIndex(
                name: "IX_MovingProducts_TypeMovingProductId",
                table: "MovingProduct",
                newName: "IX_MovingProduct_TypeMovingProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MovingProducts_PartyId",
                table: "MovingProduct",
                newName: "IX_MovingProduct_PartyId");

            migrationBuilder.RenameIndex(
                name: "IX_MovingProducts_NumberChildrenId",
                table: "MovingProduct",
                newName: "IX_MovingProduct_NumberChildrenId");

            migrationBuilder.RenameIndex(
                name: "IX_MovingProducts_DishItemFactId",
                table: "MovingProduct",
                newName: "IX_MovingProduct_DishItemFactId");

            migrationBuilder.RenameIndex(
                name: "IX_MovingProducts_Date",
                table: "MovingProduct",
                newName: "IX_MovingProduct_Date");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_SupplierId",
                table: "Invoice",
                newName: "IX_Invoice_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_DishItemFacts_ProductId",
                table: "DishItemFact",
                newName: "IX_DishItemFact_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DishItemFacts_DishFactId",
                table: "DishItemFact",
                newName: "IX_DishItemFact_DishFactId");

            migrationBuilder.RenameIndex(
                name: "IX_DishFacts_MenuFactId",
                table: "DishFact",
                newName: "IX_DishFact_MenuFactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeMovingProduct",
                table: "TypeMovingProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Party",
                table: "Party",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumberChildren",
                table: "NumberChildren",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovingProduct",
                table: "MovingProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuFact",
                table: "MenuFact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishItemFact",
                table: "DishItemFact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishFact",
                table: "DishFact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_MenuFact_MenuFactId",
                table: "Dishes",
                column: "MenuFactId",
                principalTable: "MenuFact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishFact_MenuFact_MenuFactId",
                table: "DishFact",
                column: "MenuFactId",
                principalTable: "MenuFact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishItemFact_DishFact_DishFactId",
                table: "DishItemFact",
                column: "DishFactId",
                principalTable: "DishFact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishItemFact_Products_ProductId",
                table: "DishItemFact",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Supplier_SupplierId",
                table: "Invoice",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovingProduct_DishItemFact_DishItemFactId",
                table: "MovingProduct",
                column: "DishItemFactId",
                principalTable: "DishItemFact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovingProduct_NumberChildren_NumberChildrenId",
                table: "MovingProduct",
                column: "NumberChildrenId",
                principalTable: "NumberChildren",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovingProduct_Party_PartyId",
                table: "MovingProduct",
                column: "PartyId",
                principalTable: "Party",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovingProduct_TypeMovingProduct_TypeMovingProductId",
                table: "MovingProduct",
                column: "TypeMovingProductId",
                principalTable: "TypeMovingProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Party_Invoice_InvoiceId",
                table: "Party",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Party_Products_ProductId",
                table: "Party",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Party_Supplier_SupplierId",
                table: "Party",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
