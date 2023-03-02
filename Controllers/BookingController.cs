using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingServices  _bookService;
        public BookingController(IBookingServices bookService)
        {
            _bookService = bookService;
        }
         public IActionResult IndexBooking()
        {
            return View();
        }
         public IActionResult BookingDashborad()
        {
            return View();
        }
         public IActionResult CreateBooking()
        {
            return View();
        }

         [HttpPost]
         
        public IActionResult CreateBooking(CreateBookingRequestmodel createbooking, int id)
        {
            var result = CreateBooking(createbooking, id);
            TempData["success"] = "Created Successfully.";
                // return RedirectToAction(" Customer","CustomerDashboard");
                return RedirectToAction(nameof(GetAllBooking));

        }

        //   public IActionResult CreateBooking(CreateBookingRequestmodel createBooking, int id)
        // {
        //         var a = _bookService.CreateBooking(createBooking, id);
        //         TempData["success"] = "Created Successfully.";
        //         return RedirectToAction("CustomerDashboard");
        // }


         public IActionResult Details()
        {
            return View();
        }
          public IActionResult Details(int id)
        {
           if (id != null)
            {
                var buk = _bookService.GetBooking(id);
                if (buk != null)
                {
                    return View(buk);
                }
                return NotFound();
            }
            return NotFound();
        }
        
        public IActionResult GetAllBooking()
        {
            var get = _bookService.GetAllBookings();
            return View(get);      
        }


         public IActionResult UpdateBooking(int id)
        {

            var UpBook = _bookService.GetBooking(id);
            // if (UpBook == null)
            // {
            //     return NotFound();
            // }
            return View(UpBook);
       
        }
        [HttpPost]
         public IActionResult UpdateBooking(BookingCustomerDto bookingcustomer)
        {
            var admi = _bookService.UpdateBooking(bookingcustomer);
                return RedirectToAction(nameof(GetAllBooking));
        }
         public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var Dele = _bookService.GetBooking(id);
            if(Dele == null)
            {
                return NotFound();
            }
            return View(Dele);
        }
        //  [HttpPost("{id}")]
        [HttpGet]
         public IActionResult DeleteBooking(int id)
        {
            _bookService.DeleteBooking(id);
            return RedirectToAction(nameof(GetAllBooking));
        }
        
    }
}