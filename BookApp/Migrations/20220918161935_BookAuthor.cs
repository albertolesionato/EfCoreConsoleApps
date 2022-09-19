using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookApp.Migrations
{
    public partial class BookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Tag_TagsTagId",
                table: "BookTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagId");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookAuthorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => x.BookAuthorId);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBookAuthor",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    BooksLinkBookAuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBookAuthor", x => new { x.AuthorId, x.BooksLinkBookAuthorId });
                    table.ForeignKey(
                        name: "FK_AuthorBookAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBookAuthor_BookAuthor_BooksLinkBookAuthorId",
                        column: x => x.BooksLinkBookAuthorId,
                        principalTable: "BookAuthor",
                        principalColumn: "BookAuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBookAuthor",
                columns: table => new
                {
                    AuthorsLinkBookAuthorId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookAuthor", x => new { x.AuthorsLinkBookAuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookBookAuthor_BookAuthor_AuthorsLinkBookAuthorId",
                        column: x => x.AuthorsLinkBookAuthorId,
                        principalTable: "BookAuthor",
                        principalColumn: "BookAuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookAuthor_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBookAuthor_BooksLinkBookAuthorId",
                table: "AuthorBookAuthor",
                column: "BooksLinkBookAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBookAuthor_BookId",
                table: "BookBookAuthor",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Tags_TagsTagId",
                table: "BookTag",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Tags_TagsTagId",
                table: "BookTag");

            migrationBuilder.DropTable(
                name: "AuthorBookAuthor");

            migrationBuilder.DropTable(
                name: "BookBookAuthor");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Tag_TagsTagId",
                table: "BookTag",
                column: "TagsTagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
