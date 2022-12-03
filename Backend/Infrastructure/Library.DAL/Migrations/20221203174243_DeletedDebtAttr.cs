using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DAL.Migrations
{
    public partial class DeletedDebtAttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHasDebt",
                table: "Reader");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHasDebt",
                table: "Reader",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
