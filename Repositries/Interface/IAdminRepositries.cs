using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Repositries.Interface
{
    public interface IAdminRepositries
    {
        Admin CreateAdmin(Admin admin);
        Admin UpdateAdmin(Admin admin);
        Admin DeleteAdmin(Admin admin);
        // Admin Login(string email, string passWord);
        Admin GetAdminById(int id);
        Task<Admin> GetAdminId(int id);

        Admin Get(Expression<Func<Admin, bool>> expression);

        public Admin GetAdminByEmail(string email);
        IList<Admin> GetAllALLAmin(Expression<Func<Admin, bool>> expression);

        IList<Admin> GetAllAdmin();
    }
}