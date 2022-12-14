using Domain;
using Services.Interfaces;

namespace GraphQL_Demo.Schema.Queries
{
    [ExtendObjectType("Query")]
    public class UserQuery
    {
        private readonly IUserService _userService;

        public UserQuery(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _userService.GetUserById(id);
        }
    }
}
