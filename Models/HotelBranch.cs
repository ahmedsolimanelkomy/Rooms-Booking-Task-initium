using System.ComponentModel.DataAnnotations;

namespace Rooms_Booking.Models
{
    public class HotelBranch
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        public ICollection<Booking>? Bookings { get; set; } = new HashSet<Booking>();
        public ICollection<Room>? Rooms { get; set; }
    }
}
