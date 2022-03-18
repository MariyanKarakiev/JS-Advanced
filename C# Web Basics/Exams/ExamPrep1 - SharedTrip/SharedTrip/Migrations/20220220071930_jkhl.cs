using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharedTrip.Migrations
{
    public partial class jkhl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "Username");
        }
    }
}
