using Rooms_Booking.IRepository;
using Rooms_Booking.Models;

namespace Rooms_Booking.Repository
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        private readonly RoomsBookingContext _dbcontext;
        public RoomTypeRepository(RoomsBookingContext context) : base(context)
        {
            _dbcontext = context;
        }
    }
}
