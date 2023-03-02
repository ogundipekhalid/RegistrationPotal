using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Services.Implimentation
{
    public class BookingServices : IBookingServices
    {
        private readonly IHttpContextAccessor _httpContentAccessor;
        private readonly IBookingRepositries _repo;
        private readonly IMovieRepositries _moviRepo;
        private readonly ICustomerRepositries _cutomerRepo;
        private readonly IUserRepositries _userRepositries;
        private readonly IAdminRepositries _adminRepositries;


        public BookingServices(IHttpContextAccessor httpContentAccessor, IBookingRepositries repo, IMovieRepositries moviRepo, ICustomerRepositries cutomer,
        IUserRepositries userRepositries, IAdminRepositries adminRepositries)
        {
            _httpContentAccessor = httpContentAccessor;
            _repo = repo;
            _moviRepo = moviRepo;
            _cutomerRepo = cutomer;
            _userRepositries = userRepositries;
            adminRepositries = _adminRepositries;
        }

        // public BookingResponceModel CreateBooking(CreateBookingRequestmodel createbooking, int id)
        // {
        //     var user = _httpContentAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        //     var cui = _userRepositries.GetUserById(id);
        //     if (cui == null)
        //     {
        //         cui.Balance -= createbooking.Price;
        //         _userRepositries.UpdateUser(cui);
        //     }

        //     // var booking = CreateNewBooking(cui.Id, createbooking);
        //     var booking = _repo.CreateBooking(bookingCustomer);

        //     if (booking == null)
        //     {
        //         return new BookingResponceModel
        //         {
        //             Message = "fail to create",
        //             Status = false,
        //         };
        //     }

        //     return new BookingResponceModel
        //     {
        //         Data = new BookingCustomerDto
        //         {
        //             CustomerId = booking.Id,
        //             MovieName = booking.MovieName,
        //             SitNumber = booking.SitNumber,
        //         },
        //         Message = "Successfully Created",
        //         Status = true,
        //     };
        // }

        public BookingResponceModel CreateBooking(CreateBookingRequestmodel createbooking, int id)
        {
            var user = _httpContentAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            // var cui = _cutomerRepo.GetCustomerById(int.Parse(user));
            var cui = _userRepositries.GetUserById(id);
            if (cui == null)
            {
                cui.Balance -= createbooking.Price;
                _userRepositries.UpdateUser(cui);
                var manad = _adminRepositries.GetAdminById(1);
                manad.User.Balance += createbooking.Price;
                _adminRepositries.UpdateAdmin(manad);

            }

            var Bookings = new BookingCustomer
            {
                Id = createbooking.Id,
                CustomerId = createbooking.Id,
                MovieName = createbooking.MovieName,
                Price = createbooking.Price,
                SitNumber = new Random().Next(),

            };
            var Createbook = _repo.CreateBooking(Bookings);
            if (Createbook == null)
            {
                return new BookingResponceModel
                {
                    Message = "fail to create",
                    Status = false,
                };
            }
            return new BookingResponceModel
            {
                Data = new BookingCustomerDto
                {
                    // Id = createbooking.Id,
                    CustomerId = Createbook.Id,
                    MovieName = Createbook.MovieName,
                    SitNumber = Createbook.SitNumber,
                },
                Message = "Successfully Created",
                Status = true,
            };

        }

        // public BookingCustomer CreateBooking(CreateBookingRequestmodel createbooking, string moviename,  int id)
        // {
        //     var booker = new BookingCustomer();
        //     var verifyMovieName = _moviRepo.GetMoviesbyid(id);
        //     var verifyRefnumber = _cutomerRepo.GetCustomerById(jd);
        //     if (verifyRefnumber == null)
        //     {
        //         Console.WriteLine("unrecognized Refnumber");
        //     }
        //     else
        //     {
        //         if (verifyMovieName == null)
        //         {
        //             Console.WriteLine("movie name does not exist");
        //         }
        //          booker = new BookingCustomer
        //         {
        //             Id = createbooking.Id,
        //            MovieName = createbooking.MovieName,
        //             Price = createbooking.Price,
        //             Email = createbooking.Email,
        //             SitNumber = createbooking.SitNumber,
        //             //RefNumber = createBooking.RefNumber,
        //             IsActive = true
        //         };

        //          _repo.CreateBooking(booker);
        //     }
        //     return booker;
        // }


        public bool DeleteBooking(int CustomerId)
        {
            var booki = _repo.GetBookingBy(CustomerId);
            if (booki != null)
            {
                booki.IsdDleted = true;
                return true;
            }
            return false;
            // var booki = _repo.GetBookingBy(id);
            // _repo.DeleteBooking(booki);
        }

        // public IList<BookingCustomer> GetAllBooking()
        // {
        //     return _repo.GetAllBooking();
        // }

        public BookingsResponceModels GetAllBookings()
        {
            var getbookin = _repo.GetAllBooking();
            if (getbookin == null)
            {
                return new BookingsResponceModels
                {
                    Message = "failed to fetch",
                    Status = false,
                };
            }
            return new BookingsResponceModels
            {
                Message = "successfully fetched",
                Status = true,
                Data = getbookin.Select(x => new BookingCustomerDto
                {
                    Id = x.Id,
                    CustomerId = x.Id,
                    MovieName = x.MovieName,
                    SitNumber = x.SitNumber,
                    Price = x.Price,
                }).ToList()
            };
        }

        public BookingResponceModel GetBooking(int id)
        {
            var bokeed = _repo.GetBookingBy(id);
            if (bokeed == null)
            {
                return new BookingResponceModel
                {
                    Message = "Booking  not found",
                    Status = false
                };

            }
            var book = new BookingCustomerDto
            {
                Id = bokeed.Id,
                CustomerId = bokeed.Id,
                Price = bokeed.Price,
                MovieName = bokeed.MovieName,
            };

            return new BookingResponceModel
            {
                Message = "bookig found",
                Status = false,
                Data = book,
            };
        }

        public BookingResponceModel UpdateBooking(BookingCustomerDto bookingcustomer)
        {
            var bookies = _repo.GetBookingBy(bookingcustomer.Id);
            if (bookies == null)
            {
                return new BookingResponceModel
                {
                    Message = "Updating not found",
                    Status = false
                };
            }
            bookies.MovieName = bookies.MovieName ?? bookies.MovieName;
            bookies.Price = bookies.Price < 0 ? bookies.Price : bookies.Price;
            _repo.UpdateBooking(bookies);
            // return bookingcustomer;
            return new BookingResponceModel
            {
                Message = " Updating  found",
                Status = true
            };
        }
    }
}