using System.ComponentModel.DataAnnotations;

namespace Rooms_Booking.Models
{
    public class RoomType
    {
        [Key]
        public int ID { get; set; }
        public string? TypeName { get; set; }   
        public string? Description { get; set; }

        public ICollection<Room>? Rooms { get; set; } = new HashSet<Room>();
    }
}
