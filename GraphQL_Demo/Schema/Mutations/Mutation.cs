using Domain;
using GraphQL_Demo.Models.Restaurant;
using Services.Interfaces;

namespace GraphQL_Demo.Schema.Mutations
{
    [ExtendObjectType("Mutation")]
    public class Mutation
    {
        private readonly IRestaurantService _restaurantService;

        public Mutation(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<RestaurantModel> AddRestaurant(AddRestaurantRequest request)
        {
            var restaurant = new Restaurant
            {
                Name = request.Name,
                ImageUrl = request.ImageUrl,
                Url = request.Url,
                DogFriendly = request.DogFriendly
            };

            var result = await _restaurantService.AddRestaurant(restaurant);

            var response = new RestaurantModel
            {
                Id = result.Id,
                Name = result.Name,
                ImageUrl = result.ImageUrl,
                Url = result.Url,
                DogFriendly = result.DogFriendly
            };
            return response;
        }

        public async Task<bool> DeleteRestaurant(Guid id)
        {
            try
            {
               return await _restaurantService.DeleteRestaurant(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
