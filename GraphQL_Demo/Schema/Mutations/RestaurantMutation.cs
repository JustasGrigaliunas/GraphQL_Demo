using Domain;
using GraphQL_Demo.Models.Restaurant;
using GraphQL_Demo.Schema.Subscriptions;
using HotChocolate.AspNetCore;
using HotChocolate.Subscriptions;
using Services.Interfaces;

namespace GraphQL_Demo.Schema.Mutations
{
    [ExtendObjectType("Mutation")]
    public class RestaurantMutation
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantMutation(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<RestaurantModel> AddRestaurant(AddRestaurantRequest request, [Service] ITopicEventSender topicEventSender)
        {
            var restaurant = new Restaurant
            {
                Name = request.Name,
                ImageUrl = request.ImageUrl,
                Url = request.Url,
                DogFriendly = request.DogFriendly
            };

            var result = await _restaurantService.AddRestaurant(restaurant);

            await topicEventSender.SendAsync(nameof(Subscription.RestaurantCreated), result);

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

        public async Task<RestaurantModel> UpdateRestaurant(Guid id, AddRestaurantRequest request,
            [Service] ITopicEventSender topicEventSender)
        {
            var restaurant = new Restaurant
            {
                Name = request.Name,
                ImageUrl = request.ImageUrl,
                Url = request.Url,
                DogFriendly = request.DogFriendly
            };

            var result = await _restaurantService.UpdateAsync(id, restaurant);

            if (result == null)
                throw new GraphQLException(new Error("Restaurant not found.", "RESTAURANT_NOT_FOUND"));

            string updateRestaurantTopic = $"{result.Id}_{nameof(Subscription.RestaurantUpdated)}";
            await topicEventSender.SendAsync(updateRestaurantTopic, result);

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
