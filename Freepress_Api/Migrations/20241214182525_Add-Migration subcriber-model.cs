using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freepress_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationsubcribermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_newsDbContext_AuthorDbContext_AuthorId",
                table: "newsDbContext");

            migrationBuilder.DropPrimaryKey(
                name: "PK_newsDbContext",
                table: "newsDbContext");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorDbContext",
                table: "AuthorDbContext");

            migrationBuilder.RenameTable(
                name: "newsDbContext",
                newName: "news");

            migrationBuilder.RenameTable(
                name: "AuthorDbContext",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_newsDbContext_AuthorId",
                table: "news",
                newName: "IX_news_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_news",
                table: "news",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "subscribe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscribe", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_news_Author_AuthorId",
                table: "news",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_Author_AuthorId",
                table: "news");

            migrationBuilder.DropTable(
                name: "subscribe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_news",
                table: "news");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "news",
                newName: "newsDbContext");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "AuthorDbContext");

            migrationBuilder.RenameIndex(
                name: "IX_news_AuthorId",
                table: "newsDbContext",
                newName: "IX_newsDbContext_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_newsDbContext",
                table: "newsDbContext",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorDbContext",
                table: "AuthorDbContext",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_newsDbContext_AuthorDbContext_AuthorId",
                table: "newsDbContext",
                column: "AuthorId",
                principalTable: "AuthorDbContext",
                principalColumn: "Id");
        }
    }
}
