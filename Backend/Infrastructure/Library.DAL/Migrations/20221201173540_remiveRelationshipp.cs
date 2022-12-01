using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DAL.Migrations
{
    public partial class remiveRelationshipp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Librarian_LibrarianId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "LibrarianId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Librarian_LibrarianId",
                table: "Orders",
                column: "LibrarianId",
                principalTable: "Librarian",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Librarian_LibrarianId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "LibrarianId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Librarian_LibrarianId",
                table: "Orders",
                column: "LibrarianId",
                principalTable: "Librarian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
