using Microsoft.EntityFrameworkCore.Migrations;

namespace Ethereals.Migrations
{
    public partial class Cambio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Turno",
                table: "Boards");

            migrationBuilder.AddColumn<string>(
                name: "TurnoId",
                table: "Boards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boards_TurnoId",
                table: "Boards",
                column: "TurnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_AspNetUsers_TurnoId",
                table: "Boards",
                column: "TurnoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_AspNetUsers_TurnoId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_TurnoId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "TurnoId",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "Turno",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
