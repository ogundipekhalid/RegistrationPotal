using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieMvcDate.ApplicationDbContext;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;

namespace MovieMvcDate.Repositries.Implimentation
{
    public class UserRepositries : IUserRepositries
    {
       private readonly ApplictionContext _context;
        public UserRepositries(ApplictionContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
             _context.users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User DeleteUser(User user)
        {
            _context.users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public IList<User> GetAllUser()
        {
           return _context.users.ToList();
        }

        public User GetUserById(int id)
        {
           var user =_context.users.SingleOrDefault(a => a.Admin.UserId == id || a.Customer.UserId == id);
           return user;
        }

        // public User GetUserEmail(string email)
        // {
        //      var user =_context.users.SingleOrDefault(a => a.Admin.Email == email || a.Customer.Email == email);
        //    return user;
        // }
        public User GetUserEmail(string email)
        {
             var user =_context.users.SingleOrDefault(a => a.Email == email);
           return user;
        }

        public User Login(string email, string Password)
        {
              var userr = _context.users.FirstOrDefault(a => a.Email == email && a.Password == Password);
            return userr;
        //   return   _context.users
        //             .Include(l => l.Customer)
        //             .Include(l => l.Admin)
        //         .SingleOrDefault(a => a.Email == email && a.Password == Password );
        }
        public User UpdateUser(User user)
        {
              _context.users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}