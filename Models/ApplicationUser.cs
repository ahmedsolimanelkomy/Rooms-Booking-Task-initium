using Microsoft.AspNetCore.Identity;

namespace Rooms_Booking.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int NID { get; set; }
        public override string? PhoneNumber { get; set; }
        public Boolean BookedBefore { get; set; }
        public ICollection<Booking>? Bookings { get; set; } = new HashSet<Booking>();
    }
}
