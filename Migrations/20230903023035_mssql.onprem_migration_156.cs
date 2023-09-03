using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasilApi.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonprem_migration_156 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClimaAeroporto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Umidade = table.Column<int>(type: "int", nullable: false),
                    Visibilidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PressaoAtmosferica = table.Column<int>(type: "int", nullable: false),
                    Vento = table.Column<int>(type: "int", nullable: false),
                    DirecaoVento = table.Column<int>(type: "int", nullable: false),
                    Condicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CondicaoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperatura = table.Column<int>(type: "int", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimaAeroporto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClimaCidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimaCidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrevisaoClima",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    IndiceUV = table.Column<int>(type: "int", nullable: false),
                    CondicaoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClimaCidadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisaoClima", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrevisaoClima_ClimaCidade_ClimaCidadeId",
                        column: x => x.ClimaCidadeId,
                        principalTable: "ClimaCidade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrevisaoClima_ClimaCidadeId",
                table: "PrevisaoClima",
                column: "ClimaCidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClimaAeroporto");

            migrationBuilder.DropTable(
                name: "PrevisaoClima");

            migrationBuilder.DropTable(
                name: "ClimaCidade");
        }
    }
}
