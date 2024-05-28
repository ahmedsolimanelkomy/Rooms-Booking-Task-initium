using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rooms_Booking.Models
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalRooms { get; set; }
        public Boolean DiscountApplied { get; set; }
        [ForeignKey("ApplicationUser")]
        public int ApplicationUserID { get; set; }
        [ForeignKey("HotelBranch")]
        public int HotelBranchID { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }
        public HotelBranch? HotelBranch { get; set; }
        public ICollection<Room>? Rooms { get; set; } = new HashSet<Room>();

    }
}
