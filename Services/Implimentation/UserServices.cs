using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Services.Implimentation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepositries _userRepo;
        public UserServices(IUserRepositries userRepo)
        {
            _userRepo = userRepo;
        }

        public User CreateUser(User user)
        {
            var users = new User
            {
                Password = user.Password,
                Email = user.Email,
                Role = user.Role,
            };
            _userRepo.CreateUser(user);
            return user;
        }

        public User DeleteUserUsingId(int id)
        {
            var userr = _userRepo.GetUserById(id);
            if (userr == null)
            {
                System.Console.WriteLine("deleting in prog... ");
            }
            userr.IsActive = false;
            return _userRepo.DeleteUser(userr);
        }

        public IList<User> GetAllUser()
        {
            return _userRepo.GetAllUser();
        }

        public UserDto Login(string email, string password)
        {
            var users = _userRepo.Login(email, password);
            if (users == null)
            {
                return null;
            }
            return new UserDto
            {
                Id = users.Id,
                Email = users.Email,
                Customer = users.Customer,
                Admin = users.Admin,
                IsActive = users.IsActive,
                Password = users.Password,
                Role = users.Role
            };
        }

        public User UpdateUser(User user, int id)
        {
            var userr = _userRepo.GetUserById(id);
            if (userr == null)
            {
                Console.WriteLine("upate in prog ....");
            }
            userr.Email = user.Email ?? user.Email;
            userr.Password = user.Password ?? userr.Password;
            return _userRepo.UpdateUser(userr);
        }
    }
}