using Microsoft.EntityFrameworkCore.Migrations;

namespace EarlyBird.DataAccess.Migrations
{
    public partial class FixedOffersCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferCategories_Categories_CategoryId1",
                table: "OfferCategories");

            migrationBuilder.DropIndex(
                name: "IX_OfferCategories_CategoryId1",
                table: "OfferCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "OfferCategories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferCategories_CategoryId",
                table: "OfferCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCategories_Categories_CategoryId",
                table: "OfferCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferCategories_Categories_CategoryId",
                table: "OfferCategories");

            migrationBuilder.DropIndex(
                name: "IX_OfferCategories_CategoryId",
                table: "OfferCategories");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId1",
                table: "OfferCategories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferCategories_CategoryId1",
                table: "OfferCategories",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCategories_Categories_CategoryId1",
                table: "OfferCategories",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
