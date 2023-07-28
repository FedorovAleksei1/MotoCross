﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionary.Infrastructure.Migrations
{
    public partial class DropCardIdInCardUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "CardsUser",
                type: "integer",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
