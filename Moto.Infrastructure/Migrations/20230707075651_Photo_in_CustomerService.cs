using Microsoft.EntityFrameworkCore.Migrations;

namespace Moto.Infrastructure.Migrations
{
    public partial class Photo_in_CustomerService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "CustomerServices",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServices_PhotoId",
                table: "CustomerServices",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerServices_Photos_PhotoId",
                table: "CustomerServices",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerServices_Photos_PhotoId",
                table: "CustomerServices");

            migrationBuilder.DropIndex(
                name: "IX_CustomerServices_PhotoId",
                table: "CustomerServices");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "CustomerServices");
        }
    }
}
