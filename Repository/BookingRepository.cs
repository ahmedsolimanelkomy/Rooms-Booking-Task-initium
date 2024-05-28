using Rooms_Booking.IRepository;
using Rooms_Booking.Models;

namespace Rooms_Booking.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly RoomsBookingContext _dbcontext;
        public BookingRepository(RoomsBookingContext context) : base(context)
        {
            _dbcontext = context;
        }
    }
}
