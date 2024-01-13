using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllWeKnow.App.Database.Migrations
{
    public partial class FixUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rights",
                table: "Users",
                newName: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Rights");
        }
    }
}
