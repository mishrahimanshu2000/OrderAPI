using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_info",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxIdentifier = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_info", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Product_info",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValue: 0m),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_info", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Order_info",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "INT", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_info", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_info_Customer_info_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer_info",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_Order_Details_Order_info_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Order_info",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Details_Product_info_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product_info",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrderDetail",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrderDetail", x => new { x.ProductId, x.OrderDetailId });
                    table.ForeignKey(
                        name: "FK_ProductOrderDetail_Order_Details_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "Order_Details",
                        principalColumn: "OrderDetailId");
                    table.ForeignKey(
                        name: "FK_ProductOrderDetail_Product_info_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product_info",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_OrdersOrderId",
                table: "Order_Details",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_ProductId",
                table: "Order_Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_info_CustomerId",
                table: "Order_info",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrderDetail_OrderDetailId",
                table: "ProductOrderDetail",
                column: "OrderDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrderDetail");

            migrationBuilder.DropTable(
                name: "Order_Details");

            migrationBuilder.DropTable(
                name: "Order_info");

            migrationBuilder.DropTable(
                name: "Product_info");

            migrationBuilder.DropTable(
                name: "Customer_info");
        }
    }
}
