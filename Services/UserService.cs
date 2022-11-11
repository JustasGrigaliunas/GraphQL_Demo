using Domain;
using Repository;
using Services.Interfaces;


namespace Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetAll();
        }

        public async Task<User> AddUser(User user)
        {
            return await _repository.Add(user);
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            return await _repository.Remove(new User { Id = id });
        }
    }
}
