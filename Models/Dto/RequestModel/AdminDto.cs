using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.ResponceModel;

namespace MovieMvcDate.Models.Dto.RequestModel;

    //namespace MovieMvcDate.Models.Dto.RequestModel

public class  AdminDto
{
    // face of admin for id
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public bool  IsActive { get; set; } 
}
// public class AdminResponceModel : BaseResponce
// {
//     public AdminDto Data { get; set; }
// }
public class AdminResponceModel : BaseResponce
{
    public  List<AdminDto> Data { get; set; }
}
public class CreateAdminRequestModel
{
    public int Id { get; set; }
    public int UserId {get;set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    //note dis 
    public bool IsActive {get;set;}
}
public class UpdateAdminRequestModel
{
    public int UserId { get; set; }
     public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    // public string Role {get; set;}
}

