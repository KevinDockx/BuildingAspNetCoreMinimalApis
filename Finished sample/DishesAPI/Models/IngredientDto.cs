namespace DishesAPI.Models;

public class IngredientDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public Guid DishId { get; set; }
}
