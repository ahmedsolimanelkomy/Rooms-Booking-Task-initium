namespace Rooms_Booking.ViewModels.BookingViewModels
{
    public class BookingListViewModel
    {
        public int BookingID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal Discount { get; set; }
        public bool DiscountApplied { get; set; }
        public string? BranchName { get; set; }
        public string? Location { get; set; }

    }
}
