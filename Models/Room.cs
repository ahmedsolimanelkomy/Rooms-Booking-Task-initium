using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rooms_Booking.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChilderns { get; set; }
        public int RoomTypeID { get; set; }
        [ForeignKey("HotelBranch")]
        public int HotelBranchID { get; set; }
        public RoomType? RoomType { get; set; }
        public HotelBranch? HotelBranch { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    }
}
