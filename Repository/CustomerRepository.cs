using Rooms_Booking.IRepository;
using Rooms_Booking.Models;

namespace Rooms_Booking.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly RoomsBookingContext _dbcontext;
        public CustomerRepository(RoomsBookingContext context) : base(context)
        {
            _dbcontext = context;
        }
    }
}
