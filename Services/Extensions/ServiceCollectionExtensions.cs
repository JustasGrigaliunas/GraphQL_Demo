using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services.Interfaces;

namespace Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<RestaurantRepository, RestaurantRepository>();
            services.AddScoped<UserRepository>();

            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
