using Microsoft.EntityFrameworkCore.Migrations;

namespace Moto.Infrastructure.Migrations
{
    public partial class AddOperationUserFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OperationsUser",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationsUser_UserId",
                table: "OperationsUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationsUser_AspNetUsers_UserId",
                table: "OperationsUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationsUser_AspNetUsers_UserId",
                table: "OperationsUser");

            migrationBuilder.DropIndex(
                name: "IX_OperationsUser_UserId",
                table: "OperationsUser");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OperationsUser");
        }
    }
}
