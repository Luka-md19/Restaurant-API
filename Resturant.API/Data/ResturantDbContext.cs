using Microsoft.EntityFrameworkCore;

namespace Resturant.API.Data
{
    public class ResturantDbContext : DbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {

        }

        // DbSets for the entities
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ItemDescription> ItemDescriptions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }

        // Override OnModelCreating to set up constraints and relationships, and to seed data.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding MenuCategories
            modelBuilder.Entity<MenuCategory>().HasData(
                new MenuCategory
                {
                    CategoryID = 1,
                    CategoryName = "Drinks",
                    CategoryDescription = "A variety of refreshing beverages.",
                    DisplayOrder = 1
                },
                new MenuCategory
                {
                    CategoryID = 2,
                    CategoryName = "Starters",
                    CategoryDescription = "Delicious starters to begin your meal.",
                    DisplayOrder = 2
                },
                new MenuCategory
                {
                    CategoryID = 3,
                    CategoryName = "Mix Grill Meals",
                    CategoryDescription = "Savor the flavor with our mixed grill meals.",
                    DisplayOrder = 3
                }
            );
            // Seeding MenuItems
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    ItemID = 1,
                    CategoryID = 1,
                    ItemName = "Coke",
                    Price = 1.5m,
                    ItemImage = "path/to/coke_image.jpg",
                    DisplayOrder = 1,
                    SpecialOfferID = null,
                    IsDishOfTheDay = false
                },
                new MenuItem
                {
                    ItemID = 2,
                    CategoryID = 1,
                    ItemName = "Pepsi",
                    Price = 1.5m,
                    ItemImage = "path/to/pepsi_image.jpg",
                    DisplayOrder = 2,
                    SpecialOfferID = null,
                    IsDishOfTheDay = false
                },
                new MenuItem
                {
                    ItemID = 3,
                    CategoryID = 2,
                    ItemName = "French Fries",
                    Price = 2.5m,
                    ItemImage = "path/to/french_fries_image.jpg",
                    DisplayOrder = 1,
                    SpecialOfferID = null,
                    IsDishOfTheDay = true
                }
            );


            // Seeding ItemDescriptions
            modelBuilder.Entity<ItemDescription>().HasData(
                new ItemDescription
                {
                    ItemID = 1,
                    DescriptionText = "Cool and refreshing drink",
                    Language = "English",
                    AllergenInfo = "No known allergens",
                    NutritionalInfo = "Calories: 100, Sugar: 20g"
                },
                new ItemDescription
                {
                    ItemID = 2,
                    DescriptionText = "A refreshing drink to enjoy your meal",
                    Language = "English",
                    AllergenInfo = "No known allergens",
                    NutritionalInfo = "Calories: 100, Sugar: 20g"
                },
                new ItemDescription
                {
                    ItemID = 3,
                    DescriptionText = "Crispy and delicious french fries",
                    Language = "English",
                    AllergenInfo = "Contains: Potatoes",
                    NutritionalInfo = "Calories: 300, Fat: 15g"
                }
            );

            // Seeding Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ReviewID = 1,
                    ItemID = 1,
                    Comment = "Very refreshing!",
                    Rating = 5
                },
                new Review
                {
                    ReviewID = 2,
                    ItemID = 2,
                    Comment = "Loved it!",
                    Rating = 4
                },
                new Review
                {
                    ReviewID = 3,
                    ItemID = 3,
                    Comment = "Tasty fries!",
                    Rating = 5
                }
            );

          

            modelBuilder.Entity<SpecialOffer>().HasData(
                new SpecialOffer
                {
                    OfferID = 1,
                    OfferName = "Summer Offer",
                    OfferDetails = "Get refreshing beverages at half price!",
                    IsActive = true,
                    StartDate = new DateTime(2023, 6, 1),
                    EndDate = new DateTime(2023, 8, 31)
                },
                new SpecialOffer
                {
                    OfferID = 2,
                    OfferName = "Winter Offer",
                    OfferDetails = "Enjoy warm meals with a 30% discount!",
                    IsActive = false,
                    StartDate = new DateTime(2023, 12, 1),
                    EndDate = new DateTime(2024, 2, 28)
                },
                new SpecialOffer
                {
                    OfferID = 3,
                    OfferName = "Spring Offer",
                    OfferDetails = "Fresh spring meals at a special price!",
                    IsActive = false,
                    StartDate = new DateTime(2024, 3, 1),
                    EndDate = new DateTime(2024, 5, 31)
                }
            );

        }


    }

}