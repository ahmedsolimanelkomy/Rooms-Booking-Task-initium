using Rooms_Booking.Models;
using Rooms_Booking.Validation;
using System.ComponentModel.DataAnnotations;

namespace Rooms_Booking.ViewModels.BookingViewModels
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "National ID is required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "National ID must be 14 characters long")]
        public string? NationalID { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Hotel Branch is required")]
        public string? HotelBranch { get; set; }

        [Required(ErrorMessage = "Check-in Date is required")]
        [DataType(DataType.Date)]
        [CheckInDate(ErrorMessage = "Check-in date cannot be in the past")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check-out Date is required")]
        [DataType(DataType.Date)]
        [CheckOutDate("CheckInDate", ErrorMessage = "Check-out date must be greater than check-in date")]
        public DateTime CheckOutDate { get; set; }
        public ICollection<RoomViewModel>? Rooms { get; set; } = new HashSet<RoomViewModel>();
        public ICollection<HotelBranch>? HotelBranches { get; set; } = new HashSet<HotelBranch>();
        public ICollection<RoomType>? RoomTypes { get; set; } = new HashSet<RoomType>();
    }
}
