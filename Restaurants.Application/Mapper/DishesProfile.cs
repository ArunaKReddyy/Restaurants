using AutoMapper;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mapper;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDto>().ReverseMap();
    }
}
