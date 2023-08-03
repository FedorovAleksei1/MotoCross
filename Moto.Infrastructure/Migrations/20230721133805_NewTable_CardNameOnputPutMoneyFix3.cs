using Microsoft.EntityFrameworkCore.Migrations;

namespace Moto.Infrastructure.Migrations
{
    public partial class NewTable_CardNameOnputPutMoneyFix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerServices_СustomerServiceId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "СustomerServiceId",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerServices_СustomerServiceId",
                table: "Orders",
                column: "СustomerServiceId",
                principalTable: "CustomerServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerServices_СustomerServiceId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "СustomerServiceId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerServices_СustomerServiceId",
                table: "Orders",
                column: "СustomerServiceId",
                principalTable: "CustomerServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
