using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Dto.ResponceModel;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Services.Implimentation
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepositries _repo;
        private readonly IUserRepositries _userRepo;

         public CustomerServices (ICustomerRepositries repo ,  IUserRepositries  userRepo)
        {
            _userRepo  = userRepo;
            _repo = repo;
        }

    public async Task<CustomerDto> AddMoneyToWallet(int id, double balance)
        {
            
            var customer =  _userRepo.GetUserById(id);
            var currentBalance = customer.Balance;
        
            if (balance <= 0)
            {
                return null;
                //throw new Exception("Balance should be greater than zero");
            }
   
            var newBalance = currentBalance + balance;
            customer.Balance = newBalance;
            // _repo.UpdateCustomer(customer);
            _userRepo.UpdateUser(customer);
            var customerDto = new CustomerDto
            {
                Id = customer.Id,
                Balance = newBalance
            };
            return customerDto;
        }

        public double CheckWallet(int id, double balance)
        {
            throw new NotImplementedException();
        }


        // public double CheckWallet(int id ,int balance)
        // {
        //   return _repo.GetCustomerById(id).Balance.Where(w => w.Id == balance)
        //   ?.Balance ?? throw new ArgumentException($"Customer with id {customerId} does not have a wallet with id {walletId}.");
        // }


        public CustomerDto CreateCustomer(CreateCustomerRequestmodel customer)
        {
         var useresit = _userRepo.GetUserEmail(customer.Email);
         if (useresit != null)
            {
                
                Console.WriteLine("user already exist");
                return null;
                // return new CustomerDto
                // {
                //      Message = "user already exist",
                //     Status = false,
                // };
                
            }
             var users = new User
              {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Password = customer.Password,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                // balance = 0,
                IsActive = true,
                Role = "Customer"
            };
            var uer = _userRepo.CreateUser(users);
            var cuto = new Customer
            {
                Id = customer.Id,
                UserId = uer.Id,
                IsActive = true,
            };
            var cretcutomer = _repo.CreateCustomer(cuto);
            if (cretcutomer == null)
            {
                
                Console.WriteLine("user already exist");
                return null;
                // return new CustomerDto
                // {
                //     Message = "failed to create",
                //     Status = false,
                // };
            }

            return new CustomerDto
            {
                
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password,
                PhoneNumber = customer.PhoneNumber,

                IsActive = true,
                UserId = uer.Id
              
            };
        }

        public bool Delete(int id)
        {
            var customer = _repo.GetCustomerById(id);
            if (customer != null )
            {
                customer.IsdDleted = true;
                return true;
            }
                return false;
        }


        public CustomersResponseModel GetAllCustomers()
        {
            var get = _repo.GetAllCustomer(x => true);
            if (get == null)
            {
                return new CustomersResponseModel
                 {
                    Status = false,
                    Message = "Failed to fetch",
                };
            }
                return new CustomersResponseModel
                {
                   Message = "Successfully fetch",
                    Status = true, 
                    Data = get.Select(x => new CustomerDto
                {
                     Id = x.Id,
                    UserId = x.User.Id,
                     FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Email = x.User.Email,
                    PhoneNumber = x.User.PhoneNumber,
                    IsActive = true,

                }).ToList(),

            };
        }

        public CreateCustomerRequestmodel GetCustomerById(int id)
        {
            // var cussti  =_repo.GetCustomerById(id);
            var cussti  =_repo.Get(k => k.Id == id);
             if (cussti == null)
            {
                return null;
            }
            return new CreateCustomerRequestmodel
            {
                Id = cussti.Id,
                UserId = cussti.Id,
                FirstName = cussti.User.FirstName,
                LastName = cussti.User.LastName,
                Email = cussti.User.Email,
                PhoneNumber = cussti.User.PhoneNumber,
                Password = cussti.User.PhoneNumber,
                IsActive = true,
            };
            //   var get = _repo.Get(x => x.Id == id);
            // if (get == null)
            // {
            //     return new CreateCustomerRequestmodel
            //     {
            //         Status = false,
            //         Message = "Failed to fetch",
            //     };
            // }
            // return new CreateCustomerRequestmodel
            // {
            //     Message = "Successfully fetch",
            //     Status = true
            // };
        }


        // public CreateCustomerRequestmodel GetCustomerByid(int id)
        // {
        //      var cutom = _repo.GetCustomerById(id);
        //    return new CreateCustomerRequestmodel
        //     {

        //         Id = cutom.Id,
        //         RefNumber = cutom.RefNumber,
        //         //  FirstName = cutom.FirstName,
        //         // LastName = cutom.LastName,
        //         // Email = cutom.Email,
        //         PhoneNumber = cutom.User.PhoneNumber,
        //         Password = cutom.Password,
        //         IsActive = cutom.IsActive,

        //     };
        // }

        public CreateCustomerRequestmodel UpdateCustomer(CreateCustomerRequestmodel customer, int id)
        {
            // var get = _repo.Get(x => x.Id == customer.Id);
            var get = _repo.Get(x => x.Id == id);
            if (get == null)
            {
                return null;
            }
            get.User.FirstName = customer.FirstName ?? get.User.FirstName;
            get.User.LastName = customer.LastName ?? get.User.LastName;
            get.User.PhoneNumber = customer.PhoneNumber ?? get.User.PhoneNumber;
            get.User.Email = customer.Email ?? get.User.Email;
            get.User.Password = customer.Password ?? get.User.Password;
            _repo.UpdateCustomer(get);
            return customer;
        }


        // public BaseResponce UpdateCustomer(UpdateCustomerRequestmodel customer, int id)
        // {
        //     var get = _repo.Get(x => x.Id == id);
        //      if (get == null)
        //     {
        //         return new BaseResponce
        //         {
        //             Message = "failed to Update",
        //             Status = false,
        //         };
        //     }
        //      get.User.FirstName = customer.FirstName;
        //     get.User.LastName = customer.LastName;
        //     get.User.Email = customer.Email;
        //     return new BaseResponce
        //     {
        //         Message = "successfully Updated",
        //         Status = true,
        //     };
        // }




    }
}