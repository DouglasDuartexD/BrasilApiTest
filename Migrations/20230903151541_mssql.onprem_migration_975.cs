using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasilApi.Migrations
{
    public partial class mssqlonprem_migration_975 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrevisaoClima");

            migrationBuilder.CreateTable(
                name: "PrevisaoClimaCidade",
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClimaCidadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisaoClimaCidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrevisaoClimaCidade_ClimaCidade_ClimaCidadeId",
                        column: x => x.ClimaCidadeId,
                        principalTable: "ClimaCidade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrevisaoClimaCidade_ClimaCidadeId",
                table: "PrevisaoClimaCidade",
                column: "ClimaCidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrevisaoClimaCidade");

            migrationBuilder.CreateTable(
                name: "PrevisaoClima",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClimaCidadeId = table.Column<int>(type: "int", nullable: true),
                    Condicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CondicaoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndiceUV = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    Min = table.Column<int>(type: "int", nullable: false)
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
    }
}
