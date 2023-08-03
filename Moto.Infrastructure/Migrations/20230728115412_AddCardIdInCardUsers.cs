using Microsoft.EntityFrameworkCore.Migrations;

namespace Moto.Infrastructure.Migrations
{
    public partial class AddCardIdInCardUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardUserId",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "CardsUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CardsUser_CardId",
                table: "CardsUser",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardsUser_Cards_CardId",
                table: "CardsUser",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardsUser_Cards_CardId",
                table: "CardsUser");

            migrationBuilder.DropIndex(
                name: "IX_CardsUser_CardId",
                table: "CardsUser");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "CardsUser");

            migrationBuilder.AddColumn<int>(
                name: "CardUserId",
                table: "Cards",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
