using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.API.Migrations
{
    /// <inheritdoc />
    public partial class NewM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuCategories_MenuCategoryCategoryID",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_MenuCategoryCategoryID",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "MenuCategoryCategoryID",
                table: "MenuItems");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryID",
                table: "MenuItems",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_MenuCategories_CategoryID",
                table: "MenuItems",
                column: "CategoryID",
                principalTable: "MenuCategories",
                principalColumn: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuCategories_CategoryID",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CategoryID",
                table: "MenuItems");

            migrationBuilder.AddColumn<int>(
                name: "MenuCategoryCategoryID",
                table: "MenuItems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemID",
                keyValue: 1,
                column: "MenuCategoryCategoryID",
                value: null);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemID",
                keyValue: 2,
                column: "MenuCategoryCategoryID",
                value: null);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ItemID",
                keyValue: 3,
                column: "MenuCategoryCategoryID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuCategoryCategoryID",
                table: "MenuItems",
                column: "MenuCategoryCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_MenuCategories_MenuCategoryCategoryID",
                table: "MenuItems",
                column: "MenuCategoryCategoryID",
                principalTable: "MenuCategories",
                principalColumn: "CategoryID");
        }
    }
}
