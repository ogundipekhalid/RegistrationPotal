using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class Admin :BaseEntity
    {
        public int UserId { get; set; }
        // public double Balance { get; set; }
        public  User User{ get; set; } 
         public bool IsActive {get;set;}
    }
}