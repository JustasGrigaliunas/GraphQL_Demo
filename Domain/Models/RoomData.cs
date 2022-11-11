namespace Domain.Models
{
    public class RoomData
    {
        public Guid Id { get; set; }
        public Room Room { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<Votes> Votes { get; set; }
    }
}
