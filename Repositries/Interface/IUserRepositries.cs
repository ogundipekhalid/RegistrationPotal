using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Repositries.Interface
{
    public interface IUserRepositries
    {
        User UpdateUser(User user);
        User DeleteUser(User user);
        User CreateUser(User user);
        //  User Get(Expression<Func<Customer, bool>> expression);
        User Login(string email, string Password);
        User GetUserById(int id);
        User GetUserEmail(string email);
        IList<User> GetAllUser();
    }
}