using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMvcDate.Models;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IUserServices _user;
    public HomeController(IUserServices user, ILogger<HomeController> logger)
    {
        _user = user;
        _logger = logger;
    }
     public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult LogIn()
    {
        return View();
    }
    [HttpPost, ActionName("LogIn")]
    public IActionResult LogInConfirmed(string email, string password)
    {
        if (email == null || password == null)
        {
            return View();
        }
        var user = _user.Login(email, password);
        // var use = new UserResponseModel 
        if (user == null)
        {
            // TempData["Loginmessage "] = user.Message;
            return View();
        }
        var roles = new List<string>();
        var claims = new List<Claim>
             {

                //  new Claim (ClaimTypes.Email , user.Email ),
                 new Claim (ClaimTypes.NameIdentifier , user.Id.ToString()),
                 new Claim (ClaimTypes.GivenName , user.Password ),
                 new Claim (ClaimTypes.Role , (user.Role == "Customer") ? "Customer" : ""),
                 new Claim (ClaimTypes.Role , (user.Role == "Admin") ? "Admin" : ""),

                  new Claim(ClaimTypes.NameIdentifier , user.Id.ToString())

             };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authenticatioProperties = new AuthenticationProperties();
        var principal = new ClaimsPrincipal(claimsIdentity);
        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticatioProperties);
       
         if (user.Role == "Customer")
        {
            TempData["success"] = "Login Successfully";
            return RedirectToAction( "CustomerDashborad" ,"Customer");
            //  return RedirectToAction("CreateMovie", "Customer");
        }
        if (user.Role == "Admin")
        {
            TempData["sucess"] = " Login Sucesful";
            // return  RedirectToAction(nameof(Index),"Admin");
            return RedirectToAction("AdminDashboard","Admin");
            // return RedirectToAction("", "Admin");
            // return RedirectToAction("CreateMovie", "Movie");
            // return RedirectToAction("GetAllAdmin", "Movie");
        }
       
        return RedirectToAction(nameof(Index));
    }

    public IActionResult LogOut(UserDto request)
    {
        HttpContext.Session.Clear();
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        TempData["success"] = $"{request.Email} Logged out Successfully";
        TempData.Keep();
        return RedirectToAction(nameof(Index));
    }
    
    // [Authorize(Roles = "Admin")]
    public IActionResult Users()
    {
        var users = _user.GetAllUser();
        return View(users);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


