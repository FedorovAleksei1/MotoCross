using Microsoft.EntityFrameworkCore.Migrations;

namespace Moto.Infrastructure.Migrations
{
    public partial class Order_ComentAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComentAdmin",
                table: "Orders",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComentAdmin",
                table: "Orders");
        }
    }
}
