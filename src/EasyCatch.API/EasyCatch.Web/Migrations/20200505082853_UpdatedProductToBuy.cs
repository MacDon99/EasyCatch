using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyCatch.API.Migrations
{
    public partial class UpdatedProductToBuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductToBuy_Orders_OrderId",
                table: "ProductToBuy");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "ProductToBuy",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToBuy_Orders_OrderId",
                table: "ProductToBuy",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductToBuy_Orders_OrderId",
                table: "ProductToBuy");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "ProductToBuy",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToBuy_Orders_OrderId",
                table: "ProductToBuy",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
