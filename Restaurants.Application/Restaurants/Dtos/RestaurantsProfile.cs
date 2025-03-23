using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantsProfile: Profile
{
    public RestaurantsProfile()
    {
        CreateMap<Restaurant, RestaurantsDto>()
            .ForMember(d => d.City, opt =>
                opt.MapFrom(s => s.Address == null ? null : s.Address.City))
            .ForMember(d => d.Street, opt =>
                opt.MapFrom(s => s.Address == null ? null : s.Address.Street))
            .ForMember(d => d.PostalCode, opt =>
                opt.MapFrom(s => s.Address == null ? null : s.Address.PostalCode));
    }
}