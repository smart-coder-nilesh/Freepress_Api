using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freepress_Api.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorDbContext",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experience = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    contribution = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorDbContext", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "newsDbContext",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_posting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsDbContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newsDbContext_AuthorDbContext_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorDbContext",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_newsDbContext_AuthorId",
                table: "newsDbContext",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newsDbContext");

            migrationBuilder.DropTable(
                name: "AuthorDbContext");
        }
    }
}
