using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.ApplicationDbContext;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;

namespace MovieMvcDate.Repositries.Implimentation
{
    public class BookingRepositries : IBookingRepositries
    {
        private readonly ApplictionContext _bookingcontext;
        public BookingRepositries(ApplictionContext bookingcontext)
        {
            _bookingcontext = bookingcontext;
        }
        public BookingCustomer CreateBooking(BookingCustomer bookingCustomer)
        {
            _bookingcontext.bookingcustomers.Add(bookingCustomer);
            _bookingcontext.SaveChanges();
            return bookingCustomer;
        }

        public bool DeleteBooking(BookingCustomer bookingCustomer)
        {
            _bookingcontext.bookingcustomers.Add(bookingCustomer);
            _bookingcontext.SaveChanges();
            return true;
        }

        public IList<BookingCustomer> GetAllBooking()
        {
            return _bookingcontext.bookingcustomers.ToList();
        }

        public BookingCustomer GetBookingBy(int id)
        {
            return _bookingcontext.bookingcustomers.SingleOrDefault(b => b.Id == id);
        }
        public BookingCustomer UpdateBooking(BookingCustomer bookingCustomer)
        {
            _bookingcontext.bookingcustomers.Update(bookingCustomer);
            _bookingcontext.SaveChanges();
            return bookingCustomer;
        }
    }
}