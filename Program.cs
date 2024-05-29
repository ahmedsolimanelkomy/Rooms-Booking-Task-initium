using Microsoft.EntityFrameworkCore;
using Rooms_Booking.IRepository;
using Rooms_Booking.Mappers;
using Rooms_Booking.Models;
using Rooms_Booking.Repository;

namespace Rooms_Booking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<RoomsBookingContext>(
                options => {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
                });

            builder.Services.AddSession(
               options =>
               {
                   options.IdleTimeout = TimeSpan.FromMinutes(30);
               });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
