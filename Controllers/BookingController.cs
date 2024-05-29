using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Rooms_Booking.IRepository;
using Rooms_Booking.Models;
using Rooms_Booking.Repository;
using Rooms_Booking.ViewModels.BookingViewModels;

namespace Rooms_Booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BookingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            ICollection<Booking> bookings = unitOfWork.BookingRepository.GetAll("HotelBranch").ToList();
            ICollection<BookingListViewModel> model = mapper.Map<ICollection<BookingListViewModel>>(bookings).ToList();
            return View("BookingList",model);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            Booking? Booking = unitOfWork.BookingRepository.GetById(B => B.ID == id,"Customer,HotelBranch,Rooms");
            BookingDetailsViewModel model = mapper.Map<BookingDetailsViewModel>(Booking);
            return View(model);
        }

        public ActionResult Create()
        {
            CreateViewModel model = new CreateViewModel();
            model.HotelBranches = unitOfWork.HotelBranchRepository.GetAll().ToList();
            model.RoomTypes = unitOfWork.RoomTypeRepository.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel bookingData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = unitOfWork.CustomerRepository.GetById(c => c.NID == bookingData.NationalID);

                    if (customer == null)
                    {
                        customer = new Customer
                        {
                            Name = bookingData.Name,
                            NID = bookingData.NationalID,
                            PhoneNumber = bookingData.PhoneNumber
                        };
                        unitOfWork.CustomerRepository.Add(customer);
                        unitOfWork.CustomerRepository.Save();
                    }

                    var booking = new Booking
                    {
                        CustomerID = customer.Id,
                        CheckInDate = bookingData.CheckInDate,
                        CheckOutDate = bookingData.CheckOutDate,
                        NumberOfRooms = bookingData.Rooms.Count
                    };

                    int hotelBranchID;
                    if (int.TryParse(bookingData.HotelBranch, out hotelBranchID))
                    {
                        booking.HotelBranchID = hotelBranchID;
                    }
                    else
                    {
                        // Handle parsing failure, e.g., set a default value or show an error message
                        ModelState.AddModelError("HotelBranch", "Invalid hotel branch ID.");
                        bookingData.HotelBranches = unitOfWork.HotelBranchRepository.GetAll().ToList();
                        bookingData.RoomTypes = unitOfWork.RoomTypeRepository.GetAll().ToList();
                        return View(bookingData);
                    }

                    if (customer.HasBookedPreviously)
                    {
                        booking.Discount = 0.05m;
                        booking.DiscountApplied = true;
                    }

                    foreach (var roomData in bookingData.Rooms)
                    {
                        RoomType roomType = unitOfWork.RoomTypeRepository.GetById(t => t.TypeName == roomData.RoomType);
                        var room = new Room
                        {
                            RoomTypeID = int.TryParse(roomData.RoomType, out int roomTypeID) ? roomTypeID : 1, // Set default value or handle parsing failure
                            NumberOfAdults = roomData.NumberOfAdults,
                            NumberOfChilderns = roomData.NumberOfChildren,
                            HotelBranchID = hotelBranchID,                            
                        };
                        booking.Rooms.Add(room);
                    }

                    unitOfWork.BookingRepository.Add(booking);
                    unitOfWork.BookingRepository.Save();
                    return RedirectToAction("GetBookings");
                }

                bookingData.HotelBranches = unitOfWork.HotelBranchRepository.GetAll().ToList();
                bookingData.RoomTypes = unitOfWork.RoomTypeRepository.GetAll().ToList();
                return View(bookingData);
            }
            catch (DbUpdateException ex)
            {
                // Log and handle the exception
            }
            catch (Exception ex)
            {
                // Log and handle the exception
            }

            return View(bookingData);
        }

    }
}
