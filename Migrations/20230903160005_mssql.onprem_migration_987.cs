using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasilApi.Migrations
{
    public partial class mssqlonprem_migration_987 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Method",
                table: "Logs");
        }
    }
}
