using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFolha.Migrations
{
    /// <inheritdoc />
    public partial class Dois : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Cargo_CargoId",
                table: "Funcionario");

            migrationBuilder.AlterColumn<int>(
                name: "CargoId",
                table: "Funcionario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Cargo_CargoId",
                table: "Funcionario",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "CargoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Cargo_CargoId",
                table: "Funcionario");

            migrationBuilder.AlterColumn<int>(
                name: "CargoId",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Cargo_CargoId",
                table: "Funcionario",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
