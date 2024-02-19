using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using DishesAPI.Entities;
using System.IO;

namespace DishesAPI.DbContexts;

public class DishesDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;


    public DishesDbContext(DbContextOptions<DishesDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Ingredient>().HasData(
            new(Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Beef"),
            new(Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Onion"),
            new(Guid.Parse("c19099ed-94db-44ba-885b-0ad7205d5e40"), "Dark beer"),
            new(Guid.Parse("0c4dc798-b38b-4a1c-905c-a9e76dbef17b"), "Brown piece of bread"),
            new(Guid.Parse("937b1ba1-7969-4324-9ab5-afb0e4d875e6"), "Mustard"),
            new(Guid.Parse("7a2fbc72-bb33-49de-bd23-c78fceb367fc"), "Chicory"),
            new(Guid.Parse("b5f336e2-c226-4389-aac3-2499325a3de9"), "Mayo"),
            new(Guid.Parse("c22bec27-a880-4f2a-b380-12dcd99c61fe"), "Various spices"),
            new(Guid.Parse("aab31c70-57ce-4b6d-a66c-9c1b094e915d"), "Mussels"),
            new(Guid.Parse("fef8b722-664d-403f-ae3c-05f8ed7d7a1f"), "Celery"),
            new(Guid.Parse("8d5a1b40-6677-4545-b6e8-5ba93efda0a1"), "French fries"),
            new(Guid.Parse("40563e5b-e538-4084-9587-3df74fae21d4"), "Tomato"),
            new(Guid.Parse("f350e1a0-38de-42fe-ada5-ae436378ee5b"), "Tomato paste"),
            new(Guid.Parse("d5cad9a4-144e-4a3d-858d-9840792fa65d"), "Bay leave"),
            new(Guid.Parse("b617df23-3d91-40e1-99aa-b07d264aa937"), "Carrot"),
            new(Guid.Parse("b8b9a6ae-9bcc-4fb3-b883-5974e04eda56"), "Garlic"),
            new(Guid.Parse("ecd396c3-4403-4fbf-83ca-94a8e9d859b3"), "Red wine"),
            new(Guid.Parse("c2c75b40-2453-416e-a7ed-3505b121d671"), "Coconut milk"),
            new(Guid.Parse("3bd3f0a1-87d3-4b85-94fa-ba92bd1874e7"), "Ginger"),
            new(Guid.Parse("047ab5cc-d041-486e-9d22-a0860fb13237"), "Chili pepper"),
            new(Guid.Parse("e0017fe1-773f-4a59-9730-9489833c6e8e"), "Tamarind paste"),
            new(Guid.Parse("c9b46f9c-d6ce-42c3-8736-2cddbbadee10"), "Firm fish"),
            new(Guid.Parse("a07cde83-3127-45da-bbd5-04a7c8d13aa4"), "Ginger garlic paste"),
            new(Guid.Parse("ebe94d5d-2ad8-4886-b246-05a1fad83d1c"), "Garam masala"));

        _ = modelBuilder.Entity<Dish>().HasData(
           new(Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), 
            "Flemish Beef stew with chicory" ),
           new(Guid.Parse("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), 
            "Mussels with french fries" ),
           new(Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), 
           "Ragu alla bolognaise"),
           new(Guid.Parse("fd630a57-2352-4731-b25c-db9cc7601b16"), 
           "Rendang"),
           new(Guid.Parse("98929bd4-f099-41eb-a994-f1918b724b5a"), 
           "Fish Masala"));

        _ = modelBuilder
            .Entity<Dish>()
            .HasMany(d => d.Ingredients)
            .WithMany(i => i.Dishes)
            .UsingEntity(e => e.HasData( 
                new { DishesId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), IngredientsId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                new { DishesId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), IngredientsId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                new { DishesId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), IngredientsId = Guid.Parse("c19099ed-94db-44ba-885b-0ad7205d5e40") },
                new { DishesId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), IngredientsId = Guid.Parse("0c4dc798-b38b-4a1c-905c-a9e76dbef17b") },
                new { DishesId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), IngredientsId = Guid.Parse("937b1ba1-7969-4324-9ab5-afb0e4d875e6") },
                new { DishesId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), IngredientsId = Guid.Parse("7a2fbc72-bb33-49de-bd23-c78fceb367fc") },
                new { DishesId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), IngredientsId = Guid.Parse("b5f336e2-c226-4389-aac3-2499325a3de9") },
                new { DishesId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), IngredientsId = Guid.Parse("c22bec27-a880-4f2a-b380-12dcd99c61fe") },
                new { DishesId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), IngredientsId = Guid.Parse("d5cad9a4-144e-4a3d-858d-9840792fa65d") },
                new { DishesId = Guid.Parse("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), IngredientsId = Guid.Parse("aab31c70-57ce-4b6d-a66c-9c1b094e915d") }, 
                new { DishesId = Guid.Parse("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), IngredientsId = Guid.Parse("fef8b722-664d-403f-ae3c-05f8ed7d7a1f") },
                new { DishesId = Guid.Parse("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), IngredientsId = Guid.Parse("8d5a1b40-6677-4545-b6e8-5ba93efda0a1") },
                new { DishesId = Guid.Parse("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), IngredientsId = Guid.Parse("c22bec27-a880-4f2a-b380-12dcd99c61fe") },
                new { DishesId = Guid.Parse("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), IngredientsId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                new { DishesId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), IngredientsId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                new { DishesId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), IngredientsId = Guid.Parse("40563e5b-e538-4084-9587-3df74fae21d4") },
                new { DishesId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), IngredientsId = Guid.Parse("f350e1a0-38de-42fe-ada5-ae436378ee5b") },
                new { DishesId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), IngredientsId = Guid.Parse("d5cad9a4-144e-4a3d-858d-9840792fa65d") },
                new { DishesId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), IngredientsId = Guid.Parse("fef8b722-664d-403f-ae3c-05f8ed7d7a1f") },
                new { DishesId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), IngredientsId = Guid.Parse("b617df23-3d91-40e1-99aa-b07d264aa937") },
                new { DishesId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), IngredientsId = Guid.Parse("b8b9a6ae-9bcc-4fb3-b883-5974e04eda56") },
                new { DishesId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), IngredientsId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                new { DishesId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), IngredientsId = Guid.Parse("ecd396c3-4403-4fbf-83ca-94a8e9d859b3") },
                new { DishesId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), IngredientsId = Guid.Parse("c22bec27-a880-4f2a-b380-12dcd99c61fe") },
                new { DishesId = Guid.Parse("fd630a57-2352-4731-b25c-db9cc7601b16"), IngredientsId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                new { DishesId = Guid.Parse("fd630a57-2352-4731-b25c-db9cc7601b16"), IngredientsId = Guid.Parse("c2c75b40-2453-416e-a7ed-3505b121d671") },
                new { DishesId = Guid.Parse("fd630a57-2352-4731-b25c-db9cc7601b16"), IngredientsId = Guid.Parse("b8b9a6ae-9bcc-4fb3-b883-5974e04eda56") },
                new { DishesId = Guid.Parse("fd630a57-2352-4731-b25c-db9cc7601b16"), IngredientsId = Guid.Parse("3bd3f0a1-87d3-4b85-94fa-ba92bd1874e7") },
                new { DishesId = Guid.Parse("fd630a57-2352-4731-b25c-db9cc7601b16"), IngredientsId = Guid.Parse("047ab5cc-d041-486e-9d22-a0860fb13237") },
                new { DishesId = Guid.Parse("fd630a57-2352-4731-b25c-db9cc7601b16"), IngredientsId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                new { DishesId = Guid.Parse("fd630a57-2352-4731-b25c-db9cc7601b16"), IngredientsId = Guid.Parse("e0017fe1-773f-4a59-9730-9489833c6e8e") },
                new { DishesId = Guid.Parse("fd630a57-2352-4731-b25c-db9cc7601b16"), IngredientsId = Guid.Parse("c22bec27-a880-4f2a-b380-12dcd99c61fe") },
                new { DishesId = Guid.Parse("98929bd4-f099-41eb-a994-f1918b724b5a"), IngredientsId = Guid.Parse("c9b46f9c-d6ce-42c3-8736-2cddbbadee10") },
                new { DishesId = Guid.Parse("98929bd4-f099-41eb-a994-f1918b724b5a"), IngredientsId = Guid.Parse("a07cde83-3127-45da-bbd5-04a7c8d13aa4") },
                new { DishesId = Guid.Parse("98929bd4-f099-41eb-a994-f1918b724b5a"), IngredientsId = Guid.Parse("ebe94d5d-2ad8-4886-b246-05a1fad83d1c") },
                new { DishesId = Guid.Parse("98929bd4-f099-41eb-a994-f1918b724b5a"), IngredientsId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                new { DishesId = Guid.Parse("98929bd4-f099-41eb-a994-f1918b724b5a"), IngredientsId = Guid.Parse("40563e5b-e538-4084-9587-3df74fae21d4") },
                new { DishesId = Guid.Parse("98929bd4-f099-41eb-a994-f1918b724b5a"), IngredientsId = Guid.Parse("c2c75b40-2453-416e-a7ed-3505b121d671") },
                new { DishesId = Guid.Parse("98929bd4-f099-41eb-a994-f1918b724b5a"), IngredientsId = Guid.Parse("d5cad9a4-144e-4a3d-858d-9840792fa65d") },
                new { DishesId = Guid.Parse("98929bd4-f099-41eb-a994-f1918b724b5a"), IngredientsId = Guid.Parse("047ab5cc-d041-486e-9d22-a0860fb13237") },
                new { DishesId = Guid.Parse("98929bd4-f099-41eb-a994-f1918b724b5a"), IngredientsId = Guid.Parse("c22bec27-a880-4f2a-b380-12dcd99c61fe") }
                ));

        base.OnModelCreating(modelBuilder);
    }
}
