using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionary.Infrastructure.Migrations
{
    public partial class Fix_Table_card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardNamePutMoneys_CardsUser_CardUserId",
                table: "CardNamePutMoneys");

            migrationBuilder.DropForeignKey(
                name: "FK_CardsUser_Cards_CardId",
                table: "CardsUser");

            migrationBuilder.DropIndex(
                name: "IX_CardsUser_CardId",
                table: "CardsUser");

            migrationBuilder.DropIndex(
                name: "IX_CardNamePutMoneys_CardUserId",
                table: "CardNamePutMoneys");

            migrationBuilder.RenameColumn(
                name: "CardUserId",
                table: "CardNamePutMoneys",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "CardsUser",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CardUserId",
                table: "Cards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "CardNamePutMoneys",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardsUser_CardId",
                table: "CardsUser",
                column: "CardId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CardsUser_Cards_CardId",
                table: "CardsUser",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardNamePutMoneys_AspNetUsers_UserId1",
                table: "CardNamePutMoneys");

            migrationBuilder.DropForeignKey(
                name: "FK_CardsUser_Cards_CardId",
                table: "CardsUser");

            migrationBuilder.DropIndex(
                name: "IX_CardsUser_CardId",
                table: "CardsUser");

            migrationBuilder.DropIndex(
                name: "IX_CardNamePutMoneys_UserId1",
                table: "CardNamePutMoneys");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "CardsUser");

            migrationBuilder.DropColumn(
                name: "CardUserId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CardNamePutMoneys");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CardNamePutMoneys",
                newName: "CardUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CardsUser_CardId",
                table: "CardsUser",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardNamePutMoneys_CardUserId",
                table: "CardNamePutMoneys",
                column: "CardUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CardNamePutMoneys_CardsUser_CardUserId",
                table: "CardNamePutMoneys",
                column: "CardUserId",
                principalTable: "CardsUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardsUser_Cards_CardId",
                table: "CardsUser",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
