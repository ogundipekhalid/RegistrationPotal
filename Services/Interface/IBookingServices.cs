using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Services.Interface
{
    public interface IBookingServices
    {
         public BookingResponceModel CreateBooking(CreateBookingRequestmodel createbooking, int id);
        public bool DeleteBooking(int id);
        public BookingResponceModel UpdateBooking(BookingCustomerDto bookingcustomer);
        // public BookingResponceModel UpdateBooking(BookingCustomerDto bookingcustomer, int id);
        public BookingResponceModel GetBooking(int id);
        // IList<BookingCustomer> GetAllBooking();
        BookingsResponceModels GetAllBookings();

    }
}