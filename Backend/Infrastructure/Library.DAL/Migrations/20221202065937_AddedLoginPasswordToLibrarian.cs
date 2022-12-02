using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DAL.Migrations
{
    public partial class AddedLoginPasswordToLibrarian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Librarian",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Librarian",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Librarian");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Librarian");
        }
    }
}
