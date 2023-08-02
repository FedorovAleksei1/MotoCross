using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionary.Infrastructure.Migrations
{
    public partial class fix_card_put_MoneyTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CardNamePutMoneys_CardId",
                table: "CardNamePutMoneys");

            migrationBuilder.CreateIndex(
                name: "IX_CardNamePutMoneys_CardId",
                table: "CardNamePutMoneys",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CardNamePutMoneys_CardId",
                table: "CardNamePutMoneys");

            migrationBuilder.CreateIndex(
                name: "IX_CardNamePutMoneys_CardId",
                table: "CardNamePutMoneys",
                column: "CardId",
                unique: true);
        }
    }
}
