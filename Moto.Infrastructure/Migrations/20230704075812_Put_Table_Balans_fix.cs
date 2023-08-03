using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Moto.Infrastructure.Migrations
{
    public partial class Put_Table_Balans_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Balanses_Id",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "BalansId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "BalansMoney",
                table: "Balanses");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Operations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "Balanses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Balanses_OperationId",
                table: "Balanses",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balanses_Operations_OperationId",
                table: "Balanses",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balanses_Operations_OperationId",
                table: "Balanses");

            migrationBuilder.DropIndex(
                name: "IX_Balanses_OperationId",
                table: "Balanses");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "Balanses");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Operations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "BalansId",
                table: "Operations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BalansMoney",
                table: "Balanses",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Balanses_Id",
                table: "Operations",
                column: "Id",
                principalTable: "Balanses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
