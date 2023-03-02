using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Repositries.Interface
{
    public interface IBookingRepositries
    {
        BookingCustomer CreateBooking (BookingCustomer bookingCustomer);
        BookingCustomer UpdateBooking(BookingCustomer bookingCustomer);
        bool DeleteBooking (BookingCustomer bookingCustomer);
        BookingCustomer GetBookingBy(int id);
        IList<BookingCustomer> GetAllBooking();
        // BookingCustomer Get(Expression<Func<Customer, bool>> expression);

    }
}