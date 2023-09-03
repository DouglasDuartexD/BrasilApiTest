using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasilApi.Migrations
{
    public partial class mssqlonprem_migration_141 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PrevisaoClima",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ClimaAeroporto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PrevisaoClima");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClimaAeroporto");
        }
    }
}
