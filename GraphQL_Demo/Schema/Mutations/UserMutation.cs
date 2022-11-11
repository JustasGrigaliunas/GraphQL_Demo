using Domain;
using GraphQL_Demo.Models.User;
using Services.Interfaces;

namespace GraphQL_Demo.Schema.Mutations
{
    [ExtendObjectType("Mutation")]
    public class UserMutation
    {
        private readonly IUserService _restaurantService;
        public UserMutation(IUserService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<UserModel> AddUser(AddUserRequest request)
        {
            var userDto = new User
            {
                Name = request.Name,
                Active = request.Active
            };

            var result = await _restaurantService.AddUser(userDto);

            var response = new UserModel
            {
                Id = result.Id,
                Name = result.Name,
                Active = result.Active
            };
            return response;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                return await _restaurantService.DeleteUser(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
