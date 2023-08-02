using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionary.Infrastructure.Migrations
{
    public partial class fix_event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateRange",
                table: "Events",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoEvent",
                table: "Events",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRange",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "InfoEvent",
                table: "Events");
        }
    }
}
