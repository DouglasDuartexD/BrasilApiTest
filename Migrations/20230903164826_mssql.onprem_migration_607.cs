using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasilApi.Migrations
{
    public partial class mssqlonprem_migration_607 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ErrorMessage",
                table: "Logs",
                newName: "Message");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Logs",
                newName: "ErrorMessage");
        }
    }
}
