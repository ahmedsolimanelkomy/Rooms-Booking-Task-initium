using Microsoft.EntityFrameworkCore;
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
        public ICustomerRepository CustomerRepository { get; private set; }

        RoomsBookingContext _DbContext;
        public UnitOfWork(RoomsBookingContext DbContext)
        {
            _DbContext = DbContext;
            BookingRepository = new BookingRepository(_DbContext);
            HotelBranchRepository = new HotelBranchRepository(_DbContext);
            RoomRepository = new RoomRepository(_DbContext);
            RoomTypeRepository = new RoomTypeRepository(_DbContext);
            CustomerRepository = new CustomerRepository(_DbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await _DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }
    }
}
