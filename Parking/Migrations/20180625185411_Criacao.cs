using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking.Migrations
{
    public partial class Criacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "valorCobrado",
                table: "Tickets",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valorCobrado",
                table: "Tickets");
        }
    }
}
