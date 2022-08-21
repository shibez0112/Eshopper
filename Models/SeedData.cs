using Microsoft.EntityFrameworkCore;
namespace Eshopper.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
        if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Shirt",
                    Description = "A shirt for everyone",
                    Category = "Shirts",
                    Price = 275,
                    Image = "img/tshirt.jpg"
                },
                new Product
                {
                    Name = "Jean",
                    Description = "Protective and fashionable",
                    Category = "Jeans",
                    Price = 48.95m,
                    Image = "img/jean.jpg"
                },
                new Product
                {
                    Name = "Swimwear",
                    Description = "Useable on summer",
                    Category = "Swimwear",
                    Price = 19.50m,
                    Image = "img/swimwear.jpg"
                },
                new Product
                {
                    Name = "Sleepwear",
                    Description = "Comfortable for sleeping",
                    Category = "Sleepwear",
                    Price = 34.95m,
                    Image = "img/sleepwear.jpg"
                },
                new Product
                {
                    Name = "Sportwear",
                    Description = "Best when doing sports",
                    Category = "Sportwear",
                    Price = 79500,
                    Image = "img/sportwear.jpg"
                },
                new Product
                {
                    Name = "Jumpsuit",
                    Description = "Improve flying ability by 75%",
                    Category = "Jumpsuits",
                    Price = 16,
                    Image = "img/jumpsuit.jpg"
                },
                new Product
                {
                    Name = "Blazer",
                    Description = "Very polite looks",
                    Category = "Blazers",
                    Price = 29.95m,
                    Image = "img/blazer.jpg"
                },
                new Product
                {
                    Name = "Jacket",
                    Description = "A casual look",
                    Category = "Jackets",
                    Price = 75,
                    Image = "img/jacket.jpg"
                },
                new Product
                {
                    Name = "Shoe",
                    Description = "For special events",
                    Category = "Shoes",
                    Price = 1200,
                    Image = "img/shoes.jpg"
                }
                );
            context.SaveChanges();
            }
        }
    }
}