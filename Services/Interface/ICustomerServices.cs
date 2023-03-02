using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Dto.ResponceModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Services.Interface
{
    public interface ICustomerServices
    {
        public CustomerDto CreateCustomer(CreateCustomerRequestmodel customer);
        // public BaseResponce UpdateCustomer(UpdateCustomerRequestmodel customer, int id);
        public bool Delete(int id);

        public CreateCustomerRequestmodel GetCustomerById(int id);
        public CreateCustomerRequestmodel UpdateCustomer(CreateCustomerRequestmodel customer , int id);

        public CustomersResponseModel GetAllCustomers();
        double CheckWallet(int id, double balance);
        Task<CustomerDto> AddMoneyToWallet(int id, double balance);


    }
}
/*

*/