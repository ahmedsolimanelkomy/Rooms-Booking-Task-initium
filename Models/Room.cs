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
        [ForeignKey("Booking")]
        public int BookingID { get; set; }
        [ForeignKey("RoomType")]
        public int RoomTypeID { get; set; }

        public Booking? Booking { get; set; }
        public RoomType? RoomType { get; set; }
        public HotelBranch? HotelBranch { get; set; }

    }
}
