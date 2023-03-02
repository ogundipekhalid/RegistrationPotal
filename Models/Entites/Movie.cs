using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class Movie : BaseEntity
    {  
        public string MovieName{get; set;}
        public string Director{get; set;}
        public int Year{get; set;}
        public double MoviePrice{get; set;}
        public string? MovieFliePath { get; set;}
        public DateTime TimeCreted { get; set; } = DateTime.Now;
        public DateTime Moviedate { get; set; } = DateTime.Now.AddDays(2);
        public IList<CustomerMovie> CustomerMovies { get; set; } = new List<CustomerMovie>();
        // public IList<CustomerMovie> CustomerMovies { get; set; } = new List<CustomerMovie>();
    }
}