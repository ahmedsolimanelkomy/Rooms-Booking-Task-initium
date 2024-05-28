using Rooms_Booking.IRepository;
using Rooms_Booking.Models;

namespace Rooms_Booking.Repository
{
    public class HotelBranchRepository : Repository<HotelBranch>, IHotelBranchRepository
    {
        private readonly RoomsBookingContext _dbcontext;
        public HotelBranchRepository(RoomsBookingContext context) : base(context)
        {
            _dbcontext = context;
        }
    }
}
