using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFolha.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    SalarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    INSS = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Instituicao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Agencia = table.Column<int>(type: "int", nullable: false),
                    ContaCorrente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ferias",
                columns: table => new
                {
                    FeriasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    DataInicioFerias = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFimFerias = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorFerias = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ferias", x => x.FeriasId);
                    table.ForeignKey(
                        name: "FK_Ferias_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorasTrabalhadas",
                columns: table => new
                {
                    HorasTrabalhadasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    DataHorasTrabalhadas = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraEntradaHorasTrabalhadas = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    HoraSaidaHorasTrabalhadas = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasTrabalhadas", x => x.HorasTrabalhadasId);
                    table.ForeignKey(
                        name: "FK_HorasTrabalhadas_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.PagamentoId);
                    table.ForeignKey(
                        name: "FK_Pagamento_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ferias_FuncionarioId",
                table: "Ferias",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_HorasTrabalhadas_FuncionarioId",
                table: "HorasTrabalhadas",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_FuncionarioId",
                table: "Pagamento",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ferias");

            migrationBuilder.DropTable(
                name: "HorasTrabalhadas");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
