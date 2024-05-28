using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rooms_Booking.IRepository;
using Rooms_Booking.Models;

namespace Rooms_Booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public BookingController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: BookingController
        public ActionResult Index()
        {
            var bookings = unitOfWork.BookingRepository.GetAll().ToList();
            return View(bookings);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            var Booking = unitOfWork.BookingRepository.Get(B => B.ID == id);
            return View(Booking);
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking Booking)
        {
            try
            {
                if ( ModelState.IsValid )
                {
                    unitOfWork.BookingRepository.Add(Booking);
                    unitOfWork.BookingRepository.Save();
                    RedirectToAction("Index", "Booking");
                }
                return View(Booking);
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            var Booking = unitOfWork.BookingRepository.Get(B => B.ID == id);
            return View(Booking);
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Booking Booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.BookingRepository.Update(Booking);
                    unitOfWork.BookingRepository.Save();
                    RedirectToAction("Index", "Booking");
                }
                return View(Booking);
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Booking Booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.BookingRepository.Remove(Booking);
                    unitOfWork.BookingRepository.Save();
                    RedirectToAction("Index", "Booking");
                }
                return View(Booking);
            }
            catch
            {
                return View();
            }
        }
    }
}
