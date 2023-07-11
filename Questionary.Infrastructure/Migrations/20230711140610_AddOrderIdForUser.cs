using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionary.Infrastructure.Migrations
{
    public partial class AddOrderIdForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OperationsUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OperationsUser_OrderId",
                table: "OperationsUser",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationsUser_Orders_OrderId",
                table: "OperationsUser",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationsUser_Orders_OrderId",
                table: "OperationsUser");

            migrationBuilder.DropIndex(
                name: "IX_OperationsUser_OrderId",
                table: "OperationsUser");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OperationsUser");
        }
    }
}
