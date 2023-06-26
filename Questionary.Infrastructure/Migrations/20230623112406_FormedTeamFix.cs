using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionary.Infrastructure.Migrations
{
    public partial class FormedTeamFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Athlet",
                table: "FormedTeams");

            migrationBuilder.DropColumn(
                name: "InfoAthlet",
                table: "FormedTeams");

            migrationBuilder.RenameColumn(
                name: "RealYear",
                table: "FormedTeams",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "InfoRealYear",
                table: "FormedTeams",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "FormedTeams",
                newName: "RealYear");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "FormedTeams",
                newName: "InfoRealYear");

            migrationBuilder.AddColumn<string>(
                name: "Athlet",
                table: "FormedTeams",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoAthlet",
                table: "FormedTeams",
                type: "text",
                nullable: true);
        }
    }
}
