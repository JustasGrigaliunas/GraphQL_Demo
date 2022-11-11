using Domain;

namespace Services.Interfaces
{
    public interface IRestaurantService
    {
        public Task<Restaurant?> GetRestaurantById(Guid id);
        public Task<IEnumerable<Restaurant>> GetRestaurants();
        public Task<Restaurant> AddRestaurant(Restaurant restaurant);
        public Task<bool> DeleteRestaurant(Guid id);
    }
}
