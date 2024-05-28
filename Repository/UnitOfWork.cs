using Rooms_Booking.IRepository;
using Rooms_Booking.Models;

namespace Rooms_Booking.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBookingRepository BookingRepository {  get; private set; }

        public IHotelBranchRepository HotelBranchRepository { get; private set; }

        public IRoomRepository RoomRepository { get; private set; }

        public IRoomTypeRepository RoomTypeRepository { get; private set; }

        RoomsBookingContext _DbContext;
        public UnitOfWork(RoomsBookingContext DbContext)
        {
            _DbContext = DbContext;
            BookingRepository = new BookingRepository(_DbContext);
            HotelBranchRepository = new HotelBranchRepository(_DbContext);
            RoomRepository = new RoomRepository(_DbContext);
            RoomTypeRepository = new RoomTypeRepository(_DbContext);
        }
    }
}
