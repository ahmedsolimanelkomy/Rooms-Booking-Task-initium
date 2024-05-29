using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Rooms_Booking.ViewModels.BookingViewModels
{
    public class BookingDetailsViewModel
    {
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? NationalID { get; set; }
        public string? PhoneNumber { get; set; }
        public bool HasBookedPreviously { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal Discount { get; set; }
        public bool DiscountApplied { get; set; }
        public string? BranchName { get; set; }
        public string? Location { get; set; }
    }
}
