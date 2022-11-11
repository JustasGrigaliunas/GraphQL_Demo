namespace Domain
{
    public class Votes
    {
        public Guid Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
        public bool Liked { get; set; }
        public bool Disliked { get; set; }
        public bool Clicked { get; set; }
    }
}
