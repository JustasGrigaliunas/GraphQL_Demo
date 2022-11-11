using Domain;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public Task<User?> GetUserById(Guid id);
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> AddUser(User user);
        public Task<bool> DeleteUser(Guid id);
    }
}
