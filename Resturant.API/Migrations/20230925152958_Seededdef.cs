using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resturant.API.Migrations
{
    /// <inheritdoc />
    public partial class Seededdef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ItemID", "CategoryID", "DisplayOrder", "IsDishOfTheDay", "ItemImage", "ItemName", "Price", "SpecialOfferID" },
                values: new object[,]
                {
                    { 1, 1, 1, false, "path/to/coke_image.jpg", "Coke", 1.5m, null },
                    { 2, 1, 2, false, "path/to/pepsi_image.jpg", "Pepsi", 1.5m, null },
                    { 3, 2, 1, true, "path/to/french_fries_image.jpg", "French Fries", 2.5m, null }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemDescriptions",
                keyColumn: "ItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemDescriptions",
                keyColumn: "ItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemDescriptions",
                keyColumn: "ItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SpecialOffers",
                keyColumn: "OfferID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SpecialOffers",
                keyColumn: "OfferID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SpecialOffers",
                keyColumn: "OfferID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 2);
        }
    }
}
