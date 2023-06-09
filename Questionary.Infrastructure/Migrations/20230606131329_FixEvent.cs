using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoCross.Migrations
{
    public partial class FixEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Importants_Events_EventId",
                table: "Importants");

            migrationBuilder.DropIndex(
                name: "IX_Importants_EventId",
                table: "Importants");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Importants");

            migrationBuilder.AddColumn<int>(
                name: "ImportantId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ImportantId",
                table: "Events",
                column: "ImportantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Importants_ImportantId",
                table: "Events",
                column: "ImportantId",
                principalTable: "Importants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Importants_ImportantId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ImportantId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ImportantId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Importants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Importants_EventId",
                table: "Importants",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Importants_Events_EventId",
                table: "Importants",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
