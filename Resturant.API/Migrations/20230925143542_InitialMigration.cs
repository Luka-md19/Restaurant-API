using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffers",
                columns: table => new
                {
                    OfferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffers", x => x.OfferID);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    SpecialOfferID = table.Column<int>(type: "int", nullable: true),
                    IsDishOfTheDay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "MenuCategories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItems_SpecialOffers_SpecialOfferID",
                        column: x => x.SpecialOfferID,
                        principalTable: "SpecialOffers",
                        principalColumn: "OfferID");
                });

            migrationBuilder.CreateTable(
                name: "ItemDescriptions",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    DescriptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllergenInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NutritionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDescriptions", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_ItemDescriptions_MenuItems_ItemID",
                        column: x => x.ItemID,
                        principalTable: "MenuItems",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_MenuItems_ItemID",
                        column: x => x.ItemID,
                        principalTable: "MenuItems",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryID",
                table: "MenuItems",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_SpecialOfferID",
                table: "MenuItems",
                column: "SpecialOfferID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ItemID",
                table: "Reviews",
                column: "ItemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDescriptions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropTable(
                name: "SpecialOffers");
        }
    }
}
