using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Rooms_Booking.Models
{
    public class RoomsBookingContext : DbContext
    {
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<HotelBranch>? HotelBranches { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<RoomType>? RoomTypes { get; set; }

        public RoomsBookingContext(DbContextOptions<RoomsBookingContext> Options):base(Options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}
