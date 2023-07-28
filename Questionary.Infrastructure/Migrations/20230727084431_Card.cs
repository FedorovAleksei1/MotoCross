using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Questionary.Infrastructure.Migrations
{
    public partial class Card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardNamePutMoneys_CardPutMoneys_CardPutMoneyId",
                table: "CardNamePutMoneys");

            migrationBuilder.DropTable(
                name: "CardPutMoneys");

            migrationBuilder.RenameColumn(
                name: "CardPutMoneyId",
                table: "CardNamePutMoneys",
                newName: "CardUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CardNamePutMoneys_CardPutMoneyId",
                table: "CardNamePutMoneys",
                newName: "IX_CardNamePutMoneys_CardUserId");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "CardNamePutMoneys",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDate",
                table: "CardNamePutMoneys",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CardNamePutMoneys",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CardNamePutMoneys",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "CardNamePutMoneys",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardType = table.Column<string>(type: "text", nullable: true),
                    CardNumber = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardsUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardsUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardsUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardsUser_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardNamePutMoneys_CardId",
                table: "CardNamePutMoneys",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardsUser_CardId",
                table: "CardsUser",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardsUser_UserId",
                table: "CardsUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardNamePutMoneys_Cards_CardId",
                table: "CardNamePutMoneys",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardNamePutMoneys_CardsUser_CardUserId",
                table: "CardNamePutMoneys",
                column: "CardUserId",
                principalTable: "CardsUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardNamePutMoneys_Cards_CardId",
                table: "CardNamePutMoneys");

            migrationBuilder.DropForeignKey(
                name: "FK_CardNamePutMoneys_CardsUser_CardUserId",
                table: "CardNamePutMoneys");

            migrationBuilder.DropTable(
                name: "CardsUser");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_CardNamePutMoneys_CardId",
                table: "CardNamePutMoneys");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "CardNamePutMoneys");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "CardNamePutMoneys");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CardNamePutMoneys");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CardNamePutMoneys");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "CardNamePutMoneys");

            migrationBuilder.RenameColumn(
                name: "CardUserId",
                table: "CardNamePutMoneys",
                newName: "CardPutMoneyId");

            migrationBuilder.RenameIndex(
                name: "IX_CardNamePutMoneys_CardUserId",
                table: "CardNamePutMoneys",
                newName: "IX_CardNamePutMoneys_CardPutMoneyId");

            migrationBuilder.CreateTable(
                name: "CardPutMoneys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PutMoneyOnCard = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPutMoneys", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CardNamePutMoneys_CardPutMoneys_CardPutMoneyId",
                table: "CardNamePutMoneys",
                column: "CardPutMoneyId",
                principalTable: "CardPutMoneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
