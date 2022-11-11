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

        public string Hello(string name = "World") => $"Hello, {name}!";

        public IEnumerable<Book> GetBooks()
        {
            var author = new Author("Jon Skeet");
            yield return new Book("C# in Depth", author);
            yield return new Book("C# in Depth 2nd Edition", author);
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
    public record Author(string name);

    public record Book(string title, Author author);
}
