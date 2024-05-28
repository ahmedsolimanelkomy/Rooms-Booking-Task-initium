using Rooms_Booking.IRepository;
using Rooms_Booking.Models;

namespace Rooms_Booking.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly RoomsBookingContext _dbcontext;
        public RoomRepository(RoomsBookingContext context) : base(context)
        {
            _dbcontext = context;
        }
    }
}
