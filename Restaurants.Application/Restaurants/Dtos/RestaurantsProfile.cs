using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantsProfile: Profile
{
    public RestaurantsProfile()
    {
                // source   // destination
        CreateMap<Restaurant, RestaurantsDto>()
            .ForMember(d => d.City, opt =>
                opt.MapFrom(s => s.Address == null ? null : s.Address.City))
            .ForMember(d => d.Street, opt =>
                opt.MapFrom(s => s.Address == null ? null : s.Address.Street))
            .ForMember(d => d.PostalCode, opt =>
                opt.MapFrom(s => s.Address == null ? null : s.Address.PostalCode));
        
        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address, opt =>
                opt.MapFrom(s => new Address
                {
                    City = s.City,
                    Street = s.Street,
                    PostalCode = s.PostalCode
                }));
    }
}