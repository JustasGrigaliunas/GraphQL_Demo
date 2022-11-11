namespace Domain
{
    public class Room
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? Admin { get; set; }
        public bool OnlyDogFriendly { get; set; }
    }
}
