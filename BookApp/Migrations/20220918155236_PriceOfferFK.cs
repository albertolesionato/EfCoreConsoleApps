using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApp.Migrations
{
    public partial class PriceOfferFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PriceOffers_BookId",
                table: "PriceOffers",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceOffers_Books_BookId",
                table: "PriceOffers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceOffers_Books_BookId",
                table: "PriceOffers");

            migrationBuilder.DropIndex(
                name: "IX_PriceOffers_BookId",
                table: "PriceOffers");
        }
    }
}
