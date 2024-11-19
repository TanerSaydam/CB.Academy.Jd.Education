using Bogus;
using eTicaretServer.Context;
using eTicaretServer.Models;

namespace eTicaretServer;

public static class SeedData
{
    public static void SeedProduct()
    {
        var dbContext = ServiceTool.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        for (int i = 0; i < 100; i++)
        {
            Faker faker = new();
            Product product = new()
            {
                Name = faker.Commerce.ProductName(),
                Price = Convert.ToDecimal(faker.Commerce.Price(1, 125000)),
                Stock = faker.Commerce.Random.Number(1, 150),
                ImageUrl = faker.Image.PicsumUrl()
            };

            dbContext.Products.Add(product);
        }


        dbContext.SaveChanges();
    }

    public static void SeedShoppingCart()
    {
        var dbContext = ServiceTool.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var products = dbContext.Products.OrderBy(i => i.Id).ToList();
        for (int i = 0; i < 5; i++)
        {
            var product = products[i];
            var quantity = new Random().Next(1, 150);
            ShoppingCart shoppingCart = new()
            {
                ProductId = product.Id,
                Quantity = product.Stock < quantity ? product.Stock : quantity
            };

            dbContext.Add(shoppingCart);
        }

        dbContext.SaveChanges();
    }

    public static void SeedOrder()
    {
        var dbContext = ServiceTool.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var products = dbContext.Products.OrderBy(i => i.Name).ToList();
        for (int i = 0; i < 3; i++)
        {
            var product = products[i];
            var quantity = new Random().Next(1, 150);
            Order order = new()
            {
                ProductId = product.Id,
                Quantity = product.Stock < quantity ? product.Stock : quantity,
                Price = product.Price,
                OrderDate = DateTime.Now,
            };

            dbContext.Add(order);
        }

        dbContext.SaveChanges();
    }

    public static void SeedUser()
    {
        var dbContext = ServiceTool.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        Faker faker = new();
        User user = new()
        {
            FirstName = faker.Person.FirstName,
            LastName = faker.Person.LastName,
            UserName = "jhon",
            Password = "1"
        };

        dbContext.Add(user);

        faker = new();
        user = new()
        {
            FirstName = faker.Person.FirstName,
            LastName = faker.Person.LastName,
            UserName = "admin",
            Password = "1"
        };

        dbContext.Add(user);

        faker = new();
        user = new()
        {
            FirstName = faker.Person.FirstName,
            LastName = faker.Person.LastName,
            UserName = "user",
            Password = "1"
        };

        dbContext.Add(user);

        dbContext.SaveChanges();
    }
}
