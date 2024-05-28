namespace Rooms_Booking.IRepository
{
    public interface IUnitOfWork
    {
        IBookingRepository BookingRepository { get; }
        IHotelBranchRepository HotelBranchRepository { get; }
        IRoomRepository RoomRepository { get; }
        IRoomTypeRepository RoomTypeRepository { get; }

    }
}
