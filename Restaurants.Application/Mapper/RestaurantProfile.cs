using AutoMapper;
using Restaurants.Application.Restaurants.Command.CreateResatuarant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mapper;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<UpdateRestaurantCommand, Restaurant>();
        CreateMap<CreateRestaurantCommad, Restaurant>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
            {
                City = src.City,
                PostalCode = src.PostalCode,
                Street = src.Street
            }));
        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(dest => dest.City, opt =>
            opt.MapFrom(src => src.Address!.City != null ? src.Address.City : null))
             .ForMember(dest => dest.PostalCode, opt =>
            opt.MapFrom(src => src.Address!.PostalCode != null ? src.Address.PostalCode : null))
             .ForMember(dest => dest.Street, opt =>
            opt.MapFrom(src => src.Address!.Street != null ? src.Address.Street : null));
            
    }
}
