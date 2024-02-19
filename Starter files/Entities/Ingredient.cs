using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DishesAPI.Entities;

public class Ingredient
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public required string Name { get; set; }

    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    public Ingredient()
    {  }

    [SetsRequiredMembers]
    public Ingredient(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
