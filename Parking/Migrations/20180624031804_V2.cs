using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parking",
                table: "Parking");

            migrationBuilder.RenameTable(
                name: "Parking",
                newName: "Tickets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Parking");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parking",
                table: "Parking",
                column: "id");
        }
    }
}
