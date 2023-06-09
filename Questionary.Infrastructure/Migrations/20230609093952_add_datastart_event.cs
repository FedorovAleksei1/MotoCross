using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoCross.Migrations
{
    public partial class add_datastart_event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Events",
                newName: "DateStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAnd",
                table: "Events",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAnd",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Events",
                newName: "DateTime");
        }
    }
}
