using Microsoft.EntityFrameworkCore.Migrations;

namespace LmsAPI.Migrations
{
    public partial class InitiaCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksLists",
                columns: table => new
                {
                    BooksListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookIsbn = table.Column<string>(type: "nvarchar(13)", nullable: true),
                    BookTitle = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BooksAuthor = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BookCategory = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BookPublisher = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksLists", x => x.BooksListId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksLists");
        }
    }
}
