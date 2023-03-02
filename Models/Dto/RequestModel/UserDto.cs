using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.ResponceModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Models.Dto.RequestModel
{
    public class UserDto
    {
        public int Id { get; set; }
         public string Email {get; set;}
        //  public double Balance {get; set;}
         public Customer Customer{get; set;} = null;
         public Admin Admin { get; set; } = null;
        public string Password { get; set; }
         public bool IsActive {get;set;} 
         public string Role {get; set;}
         public string Message { get; set; }
    }
    public class LoginRequestModel
    {
        public  string Email { get; set; }
        public string Password { get; set; }
    }
    public class UpdateUserRoleRequestModel
    {
        public string UserId { get; set;}
         public string Role {get; set;}
        public  string Password { get; set; }
    }
    public class UserResponseModel : BaseResponce
    {
        public UserDto Data { get; set; }

    }

}