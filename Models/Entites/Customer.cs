using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class Customer  :BaseEntity
    {
        public int UserId { get; set ;}
        //public double Balance { get; set; }
        public IList<BookingCustomer> BookingCustomers { get; set; } = new List<BookingCustomer>();
        public User User { get; set; }
        public IList<CustomerMovie> CustomerMovies { get; set; } = new List<CustomerMovie>();
        public bool IsActive { get; set; }
        // public bool IsAvailable { get; set; }

       
    }
}