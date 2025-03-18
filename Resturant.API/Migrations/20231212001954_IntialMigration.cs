using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resturant.API.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountConfigurations",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Schema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountConfigurations", x => x.AccountId);
                });

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
                name: "RestaurantData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    AccountConfigurationsAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantData_AccountConfigurations_AccountConfigurationsAccountId",
                        column: x => x.AccountConfigurationsAccountId,
                        principalTable: "AccountConfigurations",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ItemImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsDishOfTheDay = table.Column<bool>(type: "bit", nullable: false),
                    OfferID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "MenuCategories",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK_MenuItems_SpecialOffers_OfferID",
                        column: x => x.OfferID,
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

            migrationBuilder.InsertData(
                table: "AccountConfigurations",
                columns: new[] { "AccountId", "Email", "RestaurantId", "Schema" },
                values: new object[,]
                {
                    { 1, "email1@example.com", "Restaurant1", "Schema1" },
                    { 2, "email2@example.com", "Restaurant2", "Schema2" },
                    { 3, "email3@example.com", "Restaurant3", "Schema3" }
                });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "CategoryID", "CategoryDescription", "CategoryName", "DisplayOrder" },
                values: new object[,]
                {
                    { 1, "A variety of refreshing beverages.", "Drinks", 1 },
                    { 2, "Delicious starters to begin your meal.", "Starters", 2 },
                    { 3, "Savor the flavor with our mixed grill meals.", "Mix Grill Meals", 3 }
                });

            migrationBuilder.InsertData(
                table: "RestaurantData",
                columns: new[] { "Id", "AccountConfigurationsAccountId", "AccountId", "Address", "BrandCode", "Cover", "Description", "Email", "Logo", "Name", "Phone", "RestaurantId" },
                values: new object[,]
                {
                    { 1, null, 0, "123 Foodie Lane, Gourmet City", "GK001", "path/to/cover1.jpg", "A fine dining experience with a variety of international cuisines.", "contact@gourmetkitchen.com", "path/to/logo1.jpg", "The Gourmet Kitchen", "123-456-7890", "one2one" },
                    { 2, null, 0, "456 Casual Street, Food Town", "CB002", "path/to/cover2.jpg", "A casual place for friends and family to enjoy a great meal.", "hello@casualbites.com", "path/to/logo2.jpg", "Casual Bites", "234-567-8901", "Rest002" }
                });

            migrationBuilder.InsertData(
                table: "SpecialOffers",
                columns: new[] { "OfferID", "EndDate", "IsActive", "OfferDetails", "OfferName", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Get refreshing beverages at half price!", "Summer Offer", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Enjoy warm meals with a 30% discount!", "Winter Offer", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Fresh spring meals at a special price!", "Spring Offer", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "ItemID", "CategoryID", "DisplayOrder", "IsDishOfTheDay", "ItemImage", "ItemName", "OfferID", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, false, "path/to/coke_image.jpg", "Coke", 1, 1.5m },
                    { 2, 1, 2, false, "path/to/pepsi_image.jpg", "Pepsi", 2, 1.5m },
                    { 3, 2, 1, true, "path/to/french_fries_image.jpg", "French Fries", 3, 2.5m }
                });

            migrationBuilder.InsertData(
                table: "ItemDescriptions",
                columns: new[] { "ItemID", "AllergenInfo", "DescriptionText", "Language", "NutritionalInfo" },
                values: new object[,]
                {
                    { 1, "No known allergens", "Cool and refreshing drink", "English", "Calories: 100, Sugar: 20g" },
                    { 2, "No known allergens", "A refreshing drink to enjoy your meal", "English", "Calories: 100, Sugar: 20g" },
                    { 3, "Contains: Potatoes", "Crispy and delicious french fries", "English", "Calories: 300, Fat: 15g" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewID", "Comment", "ItemID", "Rating" },
                values: new object[,]
                {
                    { 1, "Very refreshing!", 1, 5 },
                    { 2, "Loved it!", 2, 4 },
                    { 3, "Tasty fries!", 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryID",
                table: "MenuItems",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_OfferID",
                table: "MenuItems",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantData_AccountConfigurationsAccountId",
                table: "RestaurantData",
                column: "AccountConfigurationsAccountId");

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
                name: "RestaurantData");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AccountConfigurations");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropTable(
                name: "SpecialOffers");
        }
    }
}
