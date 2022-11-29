using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DAL.Migrations
{
    public partial class RemoveRelationIntoLibrarianAndRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Librarian_LibrarianID",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_LibrarianID",
                table: "History");

            migrationBuilder.DropColumn(
                name: "LibrarianID",
                table: "History");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibrarianID",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_History_LibrarianID",
                table: "History",
                column: "LibrarianID");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Librarian_LibrarianID",
                table: "History",
                column: "LibrarianID",
                principalTable: "Librarian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
