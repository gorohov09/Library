using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DAL.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BookInstance_BookId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BookId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookInsatnceId",
                table: "Orders",
                column: "BookInsatnceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BookInstance_BookInsatnceId",
                table: "Orders",
                column: "BookInsatnceId",
                principalTable: "BookInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BookInstance_BookInsatnceId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BookInsatnceId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BookInstance_BookId",
                table: "Orders",
                column: "BookId",
                principalTable: "BookInstance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
