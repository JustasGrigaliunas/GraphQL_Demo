namespace Domain
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Url { get; set; }
        public bool DogFriendly { get; set; } = false;
    }
}