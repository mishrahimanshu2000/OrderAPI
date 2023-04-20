using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Details_Order_info_OrdersOrderId",
                table: "Order_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Details_Product_info_ProductId",
                table: "Order_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_info_Customer_info_CustomerId",
                table: "Order_info");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderDetail_Order_Details_OrderDetailId",
                table: "ProductOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderDetail_Product_info_ProductId",
                table: "ProductOrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_info",
                table: "Product_info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_info",
                table: "Order_info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Details",
                table: "Order_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_info",
                table: "Customer_info");

            migrationBuilder.RenameTable(
                name: "Product_info",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Order_info",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Order_Details",
                newName: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "Customer_info",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Order_info_CustomerId",
                table: "Order",
                newName: "IndexOrderCustomerId");

            migrationBuilder.RenameColumn(
                name: "OrdersOrderId",
                table: "OrderDetail",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Details_ProductId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Details_OrdersOrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "Product",
                type: "decimal(12,2)",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getDate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "OrderDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IndexProductCode",
                table: "Product",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IndexCustomerName",
                table: "Customer",
                column: "CustomerName");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderDetail_OrderDetail_OrderDetailId",
                table: "ProductOrderDetail",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderDetail_Product_ProductId",
                table: "ProductOrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderDetail_OrderDetail_OrderDetailId",
                table: "ProductOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrderDetail_Product_ProductId",
                table: "ProductOrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IndexProductCode",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IndexCustomerName",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Product_info");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "Order_Details");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Order_info");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer_info");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order_Details",
                newName: "OrdersOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductId",
                table: "Order_Details",
                newName: "IX_Order_Details_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "Order_Details",
                newName: "IX_Order_Details_OrdersOrderId");

            migrationBuilder.RenameIndex(
                name: "IndexOrderCustomerId",
                table: "Order_info",
                newName: "IX_Order_info_CustomerId");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "Product_info",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Order_Details",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order_info",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getDate())");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Order_info",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Customer_info",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_info",
                table: "Product_info",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Details",
                table: "Order_Details",
                column: "OrderDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_info",
                table: "Order_info",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_info",
                table: "Customer_info",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Details_Order_info_OrdersOrderId",
                table: "Order_Details",
                column: "OrdersOrderId",
                principalTable: "Order_info",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Details_Product_info_ProductId",
                table: "Order_Details",
                column: "ProductId",
                principalTable: "Product_info",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_info_Customer_info_CustomerId",
                table: "Order_info",
                column: "CustomerId",
                principalTable: "Customer_info",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderDetail_Order_Details_OrderDetailId",
                table: "ProductOrderDetail",
                column: "OrderDetailId",
                principalTable: "Order_Details",
                principalColumn: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrderDetail_Product_info_ProductId",
                table: "ProductOrderDetail",
                column: "ProductId",
                principalTable: "Product_info",
                principalColumn: "ProductId");
        }
    }
}
