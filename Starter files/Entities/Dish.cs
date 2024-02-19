using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DishesAPI.Entities;

public class Dish 
{ 
    [Key]
    public Guid Id { get; set; }

    // "required" modifier: compiler guarantees Name is initialized when the Dish is instantiated.
    // see: https://learn.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types
    // & https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11#required-members 
    [Required]
    [MaxLength(200)]
    public required string Name { get; set; }

    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public Dish()
    { 
    }

    [SetsRequiredMembers]
    public Dish(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
