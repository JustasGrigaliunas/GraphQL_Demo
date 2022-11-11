using System.Runtime.CompilerServices;
using Domain;
using Repository;
using Services.Interfaces;

namespace Services
{
    public class RestaurantService: IRestaurantService
    {
        private readonly RestaurantRepository _repository;

        public RestaurantService(RestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task<Restaurant?> GetRestaurantById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            return await _repository.GetAll();
        }

        public async Task<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            return await _repository.Add(restaurant);
        }

        public async Task<bool> DeleteRestaurant(Guid id)
        {
            return await _repository.Remove(new Restaurant{Id = id});
        }
    }
}