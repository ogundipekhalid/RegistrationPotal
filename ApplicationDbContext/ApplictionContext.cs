using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.ApplicationDbContext
{
    public class ApplictionContext : DbContext
    {
        public ApplictionContext(DbContextOptions<ApplictionContext> options) : base(options)
        {

        }
         public DbSet<Admin> Admins   {get; set;}
        public DbSet<BookingCustomer> bookingcustomers {get;set;}
        public DbSet<Customer> customers {get;set;}
        public DbSet<Movie> movies {get; set;}
        public DbSet<User> users {get; set;}
    }
}