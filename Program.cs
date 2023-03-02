using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using MovieMvcDate.ApplicationDbContext;
using MovieMvcDate.Repositries.Implimentation;
using MovieMvcDate.Repositries.Interface;
using MovieMvcDate.Services.Implimentation;
using MovieMvcDate.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplictionContext>(options=>options.UseMySql(
builder.Configuration.GetConnectionString("DefaultConnection"),ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
));
 builder.Services.AddScoped<IAdminRepositries , AdminRepositries>();
 builder.Services.AddScoped<IAdminServices , AdminServices>();
 builder.Services.AddScoped<IBookingRepositries , BookingRepositries>();
 builder.Services.AddScoped<IBookingServices , BookingServices>();
 builder.Services.AddScoped<ICustomerRepositries , CustomerRepositries>();
 builder.Services.AddScoped<ICustomerServices , CustomerServices>();
 builder.Services.AddScoped<ICustomerServices , CustomerServices>();
 builder.Services.AddScoped<IMovieRepositries , MovieRepositries>();
 builder.Services.AddScoped<IMovieServices , MovieService>();
 builder.Services.AddScoped<IUserRepositries , UserRepositries>();
 builder.Services.AddScoped<IUserServices , UserServices>();
builder.Services.AddHttpContextAccessor();
//  builder.Services.AddScoped<IWebHostEnvironment , IWebHostEnvironment>();
 
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(config => {
    config.LoginPath = "/Home/Index";
    config.LogoutPath = "/Home/Index";
    config.Cookie.Name = "MovieApp";         
    });
    builder.Services.AddAuthorization();

    // //session
    
    builder.Services.AddSession(options => {
    options.Cookie.Name = "MovieApp.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    });

     builder.Services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
                // options.Limits.MaxRequestBodySize = 500000000; // set maximum request body size to 500MB
            });
            builder.Services.Configure<FormOptions>(x =>
           {
            // x.MultipartBodyLengthLimit = 500000000; // set maximum form body length to 500MB
             x.ValueLengthLimit = int.MaxValue;
                 x.MultipartBodyLengthLimit = int.MaxValue; // if don't set default value is: 128 MB
               x.MultipartHeadersLengthLimit = int.MaxValue;
            });  

                
            
        
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
