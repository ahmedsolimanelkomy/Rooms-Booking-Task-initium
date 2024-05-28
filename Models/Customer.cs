using System.ComponentModel.DataAnnotations;

namespace Rooms_Booking.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int NID { get; set; }
        public string? PhoneNumber { get; set; }
        public Boolean Booked { get; set; }

        public ICollection<Booking>? Bookings { get; set; } = new HashSet<Booking>();
    }
}
