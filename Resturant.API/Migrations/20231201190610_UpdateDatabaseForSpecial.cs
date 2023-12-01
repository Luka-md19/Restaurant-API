using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseForSpecial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_SpecialOffers_SpecialOfferID",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "SpecialOfferID",
                table: "MenuItems",
                newName: "OfferID");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_SpecialOfferID",
                table: "MenuItems",
                newName: "IX_MenuItems_OfferID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_SpecialOffers_OfferID",
                table: "MenuItems",
                column: "OfferID",
                principalTable: "SpecialOffers",
                principalColumn: "OfferID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_SpecialOffers_OfferID",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "OfferID",
                table: "MenuItems",
                newName: "SpecialOfferID");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_OfferID",
                table: "MenuItems",
                newName: "IX_MenuItems_SpecialOfferID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_SpecialOffers_SpecialOfferID",
                table: "MenuItems",
                column: "SpecialOfferID",
                principalTable: "SpecialOffers",
                principalColumn: "OfferID");
        }
    }
}
