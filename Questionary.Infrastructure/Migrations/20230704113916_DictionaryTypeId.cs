using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionary.Infrastructure.Migrations
{
    public partial class DictionaryTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DictionaryId",
                table: "Operations",
                newName: "DictionaryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DictionaryTypeId",
                table: "Operations",
                newName: "DictionaryId");
        }
    }
}
