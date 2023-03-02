using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServices _customerServices;
        private readonly IHttpContextAccessor _httpContentAccessor;
        private readonly IUserServices _Userservices; 


        public CustomerController(ICustomerServices customerServices ,IUserServices Userservices )
        {
            _customerServices = customerServices;
            _Userservices = Userservices;
        }
        public IActionResult IndexCustomer()
        {
            // return View(nameof(CustomerDashborad));
            return View();
        }
        public IActionResult CustomerDashborad()
        {
            return View();
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        [ActionName ( "CreateCustomer")]
        public IActionResult CreateCustomer(CreateCustomerRequestmodel customer)
        {
                 _customerServices.CreateCustomer(customer);
                  TempData["success"] = "Registration Successfully";
                return RedirectToAction("LogIn", "Home");
        
        }

        // [Authorize(Roles = "Customer")]
        public IActionResult Delete(int id)
        {
            if (id != null)
            {
                var customer = _customerServices.GetCustomerById(id);
                if (customer == null)
                {
                    return View(customer);
                }
                return NotFound();
            }

            return NotFound();
        }
        //  [Authorize]
        // [HttpPost , ActionName("Delete")]
        [HttpGet]
        // [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomer(int id)
        {
            if (id != null)
            {
                _customerServices.Delete(id);
                return RedirectToAction(nameof(GetAllCustomer));
            }
            return NotFound();
        }
        //  [Authorize(Roles = "Customer,Admin")]
        //   [HttpGet]
        public IActionResult Details(int id)
        {
          //  if (RefNumber != null)
           // {
                    string Values = User.FindFirst(ClaimTypes.NameIdentifier).Value;
              var customer = _customerServices.GetCustomerById(id);
                // if (customer != null)
                // {
                    return View(customer);
                   // return View(nameof(GetAllCustomer));
              //  }
            //     return NotFound();
            // }
            // return NotFound();
        }
        // [Authorize(Roles = "Admin")]
        // [HttpPost]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _customerServices.GetCustomerById(id);
            
            return View(customer);

           // return View(GetAllCustomer);
        }
        // [HttpPost , ActionName("UpdateCustomer")]
        public IActionResult Update(CreateCustomerRequestmodel customer ,int id)
        {
            _customerServices.UpdateCustomer(customer ,id);
            TempData["success"] = "profile updated Successfully.";
            // return RedirectToAction( "Customer","CustomerDashborad");
            return RedirectToAction(nameof(CustomerDashborad));
        }

        public IActionResult GetAllCustomer()
        {
            var customers = _customerServices.GetAllCustomers();
            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cui = _customerServices.GetCustomerById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            // var cui = _customerServices.GetCustomerById(id);
            return View(cui);
        }
         [HttpGet]
        public IActionResult AddMoneyToWallet(int id)
        {
            var waamout = _customerServices.GetCustomerById(id);
            // TempData["Updated"] = "Wallet Funded sucessful";
            return View(waamout);
        }
      
        [HttpPost]
        public async Task<IActionResult> FundWallet(CreateCustomerRequestmodel  customers)
        {
            //  if (ModelState.IsValid && balance > 0)
            //     {
                // var user = _httpContentAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                 _customerServices.AddMoneyToWallet(customers.Id,customers.Balance);
                    TempData["Updated"] = "Wallet Funded sucessful";
                 return RedirectToAction(nameof(Details));
                //  _customerServices.AddMoneyToWallet(id, balance);
                //  return RedirectToAction(nameof(GetAllCustomer));
            //}
        //    else
        //     {
        //         ViewBag.ErrorMessage = "Please enter a valid amount";
        //         return View("Error");
        //     }
        }

    }
}