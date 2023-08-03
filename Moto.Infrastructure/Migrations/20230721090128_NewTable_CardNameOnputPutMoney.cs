using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Moto.Infrastructure.Migrations
{
    public partial class NewTable_CardNameOnputPutMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardName",
                table: "CardPutMoneys");

            migrationBuilder.DropColumn(
                name: "NameCardWriteUser",
                table: "CardPutMoneys");

            migrationBuilder.AlterColumn<decimal>(
                name: "PutMoneyOnCard",
                table: "CardPutMoneys",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.CreateTable(
                name: "CardNamePutMoneys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardPutMoneyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardNamePutMoneys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardNamePutMoneys_CardPutMoneys_CardPutMoneyId",
                        column: x => x.CardPutMoneyId,
                        principalTable: "CardPutMoneys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardNamePutMoneys_CardPutMoneyId",
                table: "CardNamePutMoneys",
                column: "CardPutMoneyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardNamePutMoneys");

            migrationBuilder.AlterColumn<decimal>(
                name: "PutMoneyOnCard",
                table: "CardPutMoneys",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardName",
                table: "CardPutMoneys",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameCardWriteUser",
                table: "CardPutMoneys",
                type: "text",
                nullable: true);
        }
    }
}
