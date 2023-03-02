using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class User : BaseEntity
    {
        // public int  Id { get; set; }
        public string FirstName  {get; set;}
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
         public double Balance { get; set; } 
        public Customer Customer { get; set; }
        public Admin Admin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role {get; set;}
        public bool IsActive {get;set;}
      

    }
}