namespace GraphQL_Demo.Models.Restaurant
{
    public class RestaurantModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Url { get; set; }
        public bool DogFriendly { get; set; } = false;
    }
}
