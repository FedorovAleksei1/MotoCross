using Microsoft.EntityFrameworkCore.Migrations;

namespace Moto.Infrastructure.Migrations
{
    public partial class New_string_in_CardTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Moto",
                table: "CardTeamUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Stag",
                table: "CardTeamUsers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Moto",
                table: "CardTeamUsers");

            migrationBuilder.DropColumn(
                name: "Stag",
                table: "CardTeamUsers");
        }
    }
}
