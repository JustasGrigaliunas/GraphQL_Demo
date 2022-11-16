using AutoMapper;
using Domain;
using RestApi_Demo.Models.Restaurant;

namespace RestApi_Demo.Mappings
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantModel>()
                .ForSourceMember(x => x.Id, opt => opt.DoNotValidate());
            CreateMap<RestaurantModel, Restaurant>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
