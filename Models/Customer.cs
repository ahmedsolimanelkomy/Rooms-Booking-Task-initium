using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Rooms_Booking.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        [MinLength(14), DisplayName("National ID")]
        public string? NID { get; set; }
        public string? PhoneNumber { get; set; }
        public bool HasBookedPreviously { get; set; }
        public ICollection<Booking>? Bookings { get; set; } = new HashSet<Booking>();
    }
}
