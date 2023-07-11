using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionary.Infrastructure.Migrations
{
    public partial class AddOperationUserFixTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Operations");

            migrationBuilder.CreateTable(
                name: "OperationOperationUser",
                columns: table => new
                {
                    OperationsId = table.Column<int>(type: "integer", nullable: false),
                    OperationsUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationOperationUser", x => new { x.OperationsId, x.OperationsUserId });
                    table.ForeignKey(
                        name: "FK_OperationOperationUser_Operations_OperationsId",
                        column: x => x.OperationsId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationOperationUser_OperationsUser_OperationsUserId",
                        column: x => x.OperationsUserId,
                        principalTable: "OperationsUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationOperationUser_OperationsUserId",
                table: "OperationOperationUser",
                column: "OperationsUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationOperationUser");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Operations",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
