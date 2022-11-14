using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DAL.Migrations
{
    public partial class newManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorEntityBookEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorEntityBookEntity",
                columns: table => new
                {
                    AuthorsISBN = table.Column<string>(type: "char(13)", nullable: false),
                    AuthorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorEntityBookEntity", x => new { x.AuthorsISBN, x.AuthorsId });
                    table.ForeignKey(
                        name: "FK_AuthorEntityBookEntity_Author_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorEntityBookEntity_Book_AuthorsISBN",
                        column: x => x.AuthorsISBN,
                        principalTable: "Book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorEntityBookEntity_AuthorsId",
                table: "AuthorEntityBookEntity",
                column: "AuthorsId");
        }
    }
}
