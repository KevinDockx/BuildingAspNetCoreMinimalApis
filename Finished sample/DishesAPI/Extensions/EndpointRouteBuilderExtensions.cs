using DishesAPI.EndpointFilters;
using DishesAPI.EndpointHandlers;
using DishesAPI.Models;

namespace DishesAPI.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterDishesEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var dishesEndpoints = endpointRouteBuilder.MapGroup("/dishes")
            .RequireAuthorization();
        var dishWithGuidIdEndpoints = dishesEndpoints.MapGroup("/{dishId:guid}");
        var dishWithGuidIdEndpointsAndLockFilters =
        endpointRouteBuilder.MapGroup("/dishes/{dishId:guid}")
            .RequireAuthorization("RequireAdminFromBelgium")
            .AddEndpointFilter(new DishIsLockedFilter(
                new("fd630a57-2352-4731-b25c-db9cc7601b16")))
            .AddEndpointFilter(new DishIsLockedFilter(
                new("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06")));

        dishesEndpoints.MapGet("", DishesHandlers.GetDishesAsync);
        dishWithGuidIdEndpoints.MapGet("", DishesHandlers.GetDishByIdAsync)
            .WithName("GetDish")
            .WithOpenApi()
            .WithSummary("Get a dish by providing an id.")
            .WithDescription("Dishes are identified by a URI containing a dish identifier.  This identifier is a GUID.  You can get one specific dish via this endpoint by providing the identifier. ");
        dishesEndpoints.MapGet("/{dishName}", DishesHandlers.GetDishByNameAsync)
            .AllowAnonymous()
            .WithOpenApi(operation =>
            {
                operation.Deprecated = true;
                return operation;
            });
        dishesEndpoints.MapPost("", DishesHandlers.CreateDishAsync)
            .RequireAuthorization("RequireAdminFromBelgium")
            .AddEndpointFilter<ValidateAnnotationsFilter>()
            .ProducesValidationProblem(400)
            .Accepts<DishForCreationDto>(
                "application/json", 
                "application/vnd.marvin.dishforcreation+json"); 
        dishWithGuidIdEndpointsAndLockFilters.MapPut("", DishesHandlers.UpdateDishAsync);
        dishWithGuidIdEndpointsAndLockFilters.MapDelete("", DishesHandlers.DeleteDishAsync)
            .AddEndpointFilter<LogNotFoundResponseFilter>(); 
    }

    public static void RegisterIngredientsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    { 
        var ingredientsEndpoints = endpointRouteBuilder.MapGroup("/dishes/{dishId:guid}/ingredients").RequireAuthorization();

        ingredientsEndpoints.MapGet("", IngredientsHandlers.GetIngredientsAsync);
        ingredientsEndpoints.MapPost("", () =>
        {
            throw new NotImplementedException();
        });

    }

}
