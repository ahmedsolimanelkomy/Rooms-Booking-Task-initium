using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Rooms_Booking.Models
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal Discount { get; set; }
        public bool DiscountApplied { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [ForeignKey("HotelBranch")]
        public int HotelBranchID { get; set; }
        public Customer? Customer { get; set; }
        public HotelBranch? HotelBranch { get; set; }
        public ICollection<Room>? Rooms { get; set; }  = new List<Room>();

    }
}
