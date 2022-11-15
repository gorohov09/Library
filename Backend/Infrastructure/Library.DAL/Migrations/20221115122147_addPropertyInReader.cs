using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DAL.Migrations
{
    public partial class addPropertyInReader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BirthYear",
                table: "Reader",
                type: "char(4)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(4)");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Reader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Reader");

            migrationBuilder.AlterColumn<string>(
                name: "BirthYear",
                table: "Reader",
                type: "char(4)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(4)",
                oldNullable: true);
        }
    }
}
