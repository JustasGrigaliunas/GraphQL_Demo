using Domain;
using Services.Interfaces;

namespace GraphQL_Demo.Schema.Queries
{
    [ExtendObjectType("Query")]
    public class Query
    {
        private readonly IRestaurantService _restaurantService;

        public Query(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        
        public async Task<IEnumerable<Restaurant>> GetRestaurants([Service] IRestaurantService restaurantService)
        {
            return await restaurantService.GetRestaurants();
        }

        public async Task<Restaurant?> GetRestaurantById(Guid id)
        {
            return await _restaurantService.GetRestaurantById(id);
        }
    }

    
}
