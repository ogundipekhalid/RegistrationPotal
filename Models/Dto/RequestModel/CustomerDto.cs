using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.ResponceModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Models.Dto.RequestModel
{
    public class CustomerDto 
    {
         public int Id { get; set; }
        public int UserId {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public Guid RefNumber { get; set; }  = Guid.NewGuid().ToString("CUT").Substring(0,20).Replace('/',' ');
        public string Email { get; set; }
        public double Balance{get; set;}
        public string Password { get; set; }
        public bool IsActive {get; set;} = false;
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        //not may remove 
        // public double Walliet { get; set; }
    }
    public class CreateCustomerRequestmodel 
    {
         public int Id { get; set; }
        public int UserId {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
         public bool IsActive { get; set; }
          public double Balance{ get;set;}
          public string Role{ get;set;}

       
    }
    public class WalletRequestModel
    {
          public int Id { get; set; }
        public double Balance {get;set;}
    }
    public class UpdateCustomerRequestmodel
    {        
        public int Id { get; set; }
        public int UserId {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    
    
    public class CustomersResponseModel : BaseResponce
    {
        public  IList<CustomerDto> Data { get; set; }
    }

    public class CustomerResponseModel : BaseResponce
    {
        public  CustomerDto Data { get; set; }
    }
}