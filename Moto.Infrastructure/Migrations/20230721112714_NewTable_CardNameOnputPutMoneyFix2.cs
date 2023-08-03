using Microsoft.EntityFrameworkCore.Migrations;

namespace Moto.Infrastructure.Migrations
{
    public partial class NewTable_CardNameOnputPutMoneyFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CardNamePutMoneys_CardPutMoneyId",
                table: "CardNamePutMoneys");

            migrationBuilder.CreateIndex(
                name: "IX_CardNamePutMoneys_CardPutMoneyId",
                table: "CardNamePutMoneys",
                column: "CardPutMoneyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CardNamePutMoneys_CardPutMoneyId",
                table: "CardNamePutMoneys");

            migrationBuilder.CreateIndex(
                name: "IX_CardNamePutMoneys_CardPutMoneyId",
                table: "CardNamePutMoneys",
                column: "CardPutMoneyId");
        }
    }
}
