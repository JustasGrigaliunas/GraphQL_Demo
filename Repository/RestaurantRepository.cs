using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Generic;

namespace Repository
{
    public class RestaurantRepository : GenericRepository<Restaurant>
    {
        public RestaurantRepository(IDbContextFactory<Context> contextFactory) : base(contextFactory)
        {
        }
        //public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        //{
        //    return await _context.Restaurants.ToListAsync();
        //}
        //public async Task<Restaurant?> GetRestaurantByIdAsync(Guid id)
        //{
        //    return await _context.Restaurants.FindAsync(id);
        //}
        //public async Task AddRestaurantAsync(Restaurant model)
        //{
        //    _context.Restaurants.Add(model);

        //    await _context.SaveChangesAsync();
        //}
        //public async Task DeleteRestaurantAsync(Restaurant model)
        //{
        //    _context.Restaurants.Remove(model);

        //    await _context.SaveChangesAsync();
        //}

    }
}