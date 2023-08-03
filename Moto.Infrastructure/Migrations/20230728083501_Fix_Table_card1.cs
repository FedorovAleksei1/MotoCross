using Microsoft.EntityFrameworkCore.Migrations;

namespace Moto.Infrastructure.Migrations
{
    public partial class Fix_Table_card1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardNamePutMoneys_AspNetUsers_UserId1",
                table: "CardNamePutMoneys");

            migrationBuilder.DropIndex(
                name: "IX_CardNamePutMoneys_UserId1",
                table: "CardNamePutMoneys");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CardNamePutMoneys");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CardNamePutMoneys",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_CardNamePutMoneys_UserId",
                table: "CardNamePutMoneys",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardNamePutMoneys_AspNetUsers_UserId",
                table: "CardNamePutMoneys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardNamePutMoneys_AspNetUsers_UserId",
                table: "CardNamePutMoneys");

            migrationBuilder.DropIndex(
                name: "IX_CardNamePutMoneys_UserId",
                table: "CardNamePutMoneys");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CardNamePutMoneys",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "CardNamePutMoneys",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardNamePutMoneys_UserId1",
                table: "CardNamePutMoneys",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CardNamePutMoneys_AspNetUsers_UserId1",
                table: "CardNamePutMoneys",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
