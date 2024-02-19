using AutoMapper;
using DishesAPI.Entities;
using DishesAPI.Models;

namespace DishesAPI.Profiles;

public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDto>();
        CreateMap<DishForCreationDto, Dish>(); 
        CreateMap<DishForUpdateDto, Dish>();
    }
}
