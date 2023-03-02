using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Repositries.Interface
{
    public interface ICustomerRepositries
    {
         Customer CreateCustomer(Customer customer );
        Customer UpdateCustomer(Customer customer);
        // Customer UpdatePassword(Customer customer);
        bool DeleteCustomer(Customer customer);
        Customer GetCustomerById(int id);
        Customer Get(Expression<Func<Customer, bool>> expression);
        IList<Customer> GetAllCustomer(Expression<Func<Customer, bool>> expression);
           Task<Customer> AddMoneyToWallet(int id, double balance);
         double CheckWallet (int id , double balance);
    }
}