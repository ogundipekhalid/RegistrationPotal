using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Services.Interface
{
    public interface IUserServices
    {

        User UpdateUser(User user,int id);
        User DeleteUserUsingId(int id);
        User CreateUser(User user);
        UserDto Login(string email,string password);
        IList<User> GetAllUser(); 
    }
}