using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionary.Infrastructure.Migrations
{
    public partial class fix_card_wiht_operation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardNamePutMoneys_Cards_CardId",
                table: "CardNamePutMoneys");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "CardNamePutMoneys",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CardNamePutMoneys_Cards_CardId",
                table: "CardNamePutMoneys",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardNamePutMoneys_Cards_CardId",
                table: "CardNamePutMoneys");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "CardNamePutMoneys",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_CardNamePutMoneys_Cards_CardId",
                table: "CardNamePutMoneys",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
