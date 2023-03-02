using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.ResponceModel;

namespace MovieMvcDate.Models.Dto.RequestModel
{
     public class MovieDto
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        // public string MovieFlieType { get; set; }
        public string MovieFliePath { get; set; }
        public double MoviePrice { get; set; }
         public DateTime TimeCreted   {get; set;} =  DateTime.Now;
        public DateTime Moviedate{get; set;} = DateTime.Now.AddDays(+2);
    }
    public class CreateMovieRequestmodel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string? MovieFliePath { get; set; }
        public double MoviePrice { get; set; }
        public DateTime TimeCreted { get; set; } = DateTime.Now;
        public IFormFile incomingFiles { get; set; }
        public DateTime Moviedate { get; set; } = DateTime.Now.AddDays(2);


 }
    public class TestRequestmodel
    {
        public string MovieName { get; set; }
        public IFormFile MovieFlieType { get; set; }
    }
   
      public class MoviebyRequestModel
    {
        public string MovieName {get;set;}
        // public int Quantity{get;set;}
        public int MoviePrice { get; set; }
    }

    public class UpdateMovieResponceModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MovieName { get; set; }
        // public double MoviePrice { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
       

    }

    public class MovieResponceModel : BaseResponce
    {
        public MovieDto Data { get; set; }
    }
    public class MoviesResponceModels : BaseResponce
    {
        public IList<MovieDto> Data { get; set; }
    }

     public class MoviePaymentViewModel
    {
        public string MovieName { get; set; }
        public double MoviePrice { get; set; }
        public decimal Balance { get; set; }
        
    }

}

   