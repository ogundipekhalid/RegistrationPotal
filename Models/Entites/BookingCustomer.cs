using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class BookingCustomer : BaseEntity
    {
        public string MovieName{get;set;}
        public int CustomerId {get;set;} 
        public int SitNumber { get; set; } = new Random().Next();
        public Customer Customer { get; set; }
        public double Price { get; set; }
    }
}
/*

    */