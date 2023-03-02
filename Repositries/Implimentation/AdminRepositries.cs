using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieMvcDate.ApplicationDbContext;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;

namespace MovieMvcDate.Repositries.Implimentation
{
    public class AdminRepositries :IAdminRepositries
    {
        public readonly ApplictionContext _admincontext;

         public AdminRepositries(ApplictionContext admincontext)
        {
            _admincontext = admincontext;
        }
        public Admin CreateAdmin(Admin admin)
        {
          _admincontext.Admins.Add(admin);
          _admincontext.SaveChanges();
          return admin;
        }
        public Admin DeleteAdmin(Admin admin)
        {
            _admincontext.Admins.Remove(admin);
            _admincontext.SaveChanges();
            return admin;
        }

        public Admin Get(Expression<Func<Admin, bool>> expression)
        {
              var geti = _admincontext.Admins.Include(x => x.User).FirstOrDefault(expression);
            return geti;
        }

        public Admin GetAdminByEmail(string email)
        {
             var admini = _admincontext.Admins.SingleOrDefault(x => x.User.Email == email);
            return admini;
        }
        public async Task<Admin> GetAdminId(int id)
        {
           var va =    _admincontext.Admins.Include(c => c.User).SingleOrDefault(c => c.User.Id == id);
            return va;
        }

        public Admin GetAdminById(int id)
        {
           return _admincontext.Admins.Include(x => x.User).SingleOrDefault(v =>v.User.Id == id);
        }
        /*.Include(x=>x.User).FirstOrDefaultAsync(a => a.User.Id == id);
         return await _context.Admins.Include(x=>x.User).FirstOrDefaultAsync(a => a.User.Id == id);
        */
        // public Admin GetAdminId(int id)
        // {
        //    return _admincontext.Admins.SingleOrDefault(a => a.UserId == id);
        // }
        public IList<Admin> GetAllAdmin()
        {
            return _admincontext.Admins.ToList();
        }


        public IList<Admin> GetAllALLAmin(Expression<Func<Admin, bool>> expression)
        {
             var get = _admincontext.Admins.Include(x => x.User).Where(expression).ToList();
            return get;
        }

        public Admin UpdateAdmin(Admin admin)
        {
            _admincontext.Admins.Update(admin);
            _admincontext.SaveChanges();
            return admin;
        }

    
    }
}