namespace GraphQL_Demo.Schema.Queries
{
    [ExtendObjectType("Query")]
    public class ExampleQuery
    {
        public string Hello(string name = "World") => $"Hello, {name}!";

        public IEnumerable<Book> GetBooks()
        {
            var author = new Author("Jon Skeet");
            yield return new Book("C# in Depth", author);
            yield return new Book("C# in Depth 2nd Edition", author);
        }
    }
    public record Author(string name);

    public record Book(string title, Author author);
}
