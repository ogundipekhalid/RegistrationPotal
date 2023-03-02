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
    public class CustomerRepositries : ICustomerRepositries
    {
        private readonly ApplictionContext _customercontext;
        public CustomerRepositries (ApplictionContext customercontext)
        {
            _customercontext = customercontext;
        }

        public async Task<Customer> AddMoneyToWallet(int id, double balance)
        {
            return await _customercontext.customers.Include(a => a.User).FirstOrDefaultAsync(a => a.Id == id);
            // return await _customercontext.users.Include(a => a.Customer).ThenInclude(a =>a.Balance).FirstOrDefaultAsync(a => a.Id == id);
        }

        public double CheckWallet(int id, double balance)
        {
           var wallet = _customercontext.customers.FirstOrDefault(w => w.Id == id);
           return balance;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _customercontext.customers.Add(customer);
            _customercontext.SaveChanges();
            return customer;
        }

        public bool DeleteCustomer(Customer customer)
        {
           _customercontext.customers.Remove(customer);
            _customercontext.SaveChanges();
            return true;
        }

        public Customer Get(Expression<Func<Customer, bool>> expression)
        {
            var get = _customercontext.customers.Include(x => x.User).FirstOrDefault(expression);
            return get;
        }

        public IList<Customer> GetAllCustomer(Expression<Func<Customer, bool>> expression)
        {
            var getall = _customercontext.customers.Include(x => x.User).Where(expression).ToList();
            return getall;
        }

        // public IList<Customer> GetAllCustomers()
        // {
        //     return  _customercontext.customers.ToList();
        // }

          public Customer GetCustomerByEmail(string email)
        {
           var getcusto = _customercontext.customers.SingleOrDefault(g => g.User.Email == email);
           return getcusto;
        }

        public Customer GetCustomerById(int id)
        {
            var getcuid = _customercontext.customers.Include(a=> a.User).SingleOrDefault(i => i.Id == id);
            return getcuid;
        }
        // public Customer GetCustomeId(int id)
        // {
        //     var getcuid = _customercontext.users.Include(c => c.Customer ).FirstOrDefaultAsync(c => c.Id == id);
        //     return user;
        // }
        public async Task<Customer> GetCustomerId(int id)
        {
            return await  _customercontext.customers.FirstOrDefaultAsync(i => i.Id == id);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _customercontext.customers.Update(customer);
            _customercontext.SaveChanges();
            return customer;    
        }

        public Customer UpdatePassword(Customer customer)
        {
            throw new NotImplementedException();
        }

        //  bool DeleteCustomer(Customer customer)
        //  {
        //       _customercontext.customers.Remove(customer);
        //     _customercontext.SaveChanges();
        //     return true;
        //  }

    }
}