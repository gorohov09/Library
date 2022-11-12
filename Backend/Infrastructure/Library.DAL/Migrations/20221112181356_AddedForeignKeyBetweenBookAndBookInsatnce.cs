using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DAL.Migrations
{
    public partial class AddedForeignKeyBetweenBookAndBookInsatnce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookInstance_ISBN",
                table: "BookInstance",
                column: "ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_BookInstance_Book_ISBN",
                table: "BookInstance",
                column: "ISBN",
                principalTable: "Book",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInstance_Book_ISBN",
                table: "BookInstance");

            migrationBuilder.DropIndex(
                name: "IX_BookInstance_ISBN",
                table: "BookInstance");
        }
    }
}
