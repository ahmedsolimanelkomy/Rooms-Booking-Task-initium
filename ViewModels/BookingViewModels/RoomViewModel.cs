using System.ComponentModel.DataAnnotations;

namespace Rooms_Booking.ViewModels.BookingViewModels
{
    public class RoomViewModel
    {
        [Required]
        public string? RoomType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of adults must be at least 1.")]
        public int NumberOfAdults { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Number of children cannot be negative.")]
        public int NumberOfChildren { get; set; }
    }
}
