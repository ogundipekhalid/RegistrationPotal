using System.Linq.Expressions;
using System.Security.Claims;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Dto.ResponceModel;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Services.Implimentation
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepositries _repo;
        private readonly IUserRepositries _userRepo;
        //  private readonly IHttpContextAccessor _httpContextAccessor;
         public AdminServices(IAdminRepositries repo, IUserRepositries userRepo )
        {
            _repo = repo;
            _userRepo = userRepo;
            //  _httpContextAccessor = httpContextAccessor;
        }

        public CreateAdminRequestModel CreateAdmin(CreateAdminRequestModel admin)
        {
            var useresit = _userRepo.GetUserEmail(admin.Email);
            if (useresit != null)
            {
                Console.WriteLine("user already exist");
                return null;
            }
            var users = new User
              {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Password = admin.Password,
                PhoneNumber = admin.PhoneNumber,
                Email = admin.Email,
                IsActive = true,
                Role = "Admin"
            };
            var use = _userRepo.CreateUser(users);
            var admn = new Admin
            {
                Id = admin.Id,
                UserId = use.Id,
                IsActive = true,
            };
            
           var creteAdmin = _repo.CreateAdmin(admn);
        //    if (creteAdmin !=null )
        //    {
        //       return null;
        //     }
            return new CreateAdminRequestModel
            {
                
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                Password = admin.Password,
                PhoneNumber = admin.PhoneNumber,
                IsActive = true,
                UserId = use.Id
            };
        }

        public void DeleteAdmin(int id)
        {
            var adm = _repo.GetAdminById(id);
        }

        public AdminResponceModel GetAllAdmin()
        {
            var getall = _repo.GetAllALLAmin(a => true);
            if (getall == null)
            {
                return new AdminResponceModel
                {
                   Status = false,
                    Message = "Failed to fetch",
                };
            }
            return new AdminResponceModel
            {
                Message = "Successfully fetch",
                Status = true,
                Data = getall.Select(x => new AdminDto
                { 
                    Id = x.Id,
                    UserId = x.User.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Email = x.User.Email,
                    PhoneNumber = x.User.PhoneNumber,
                  //  Password = x.User.Password,
                    IsActive = true,

                }).ToList(),

            };
        }

        // public AdminResponceModel GetAdminByEmail(string email)
        // {
        //      var admgmail = _userRepo.GetUserEmail(email);
        //     if (admgmail == null)
        //     {
        //         return null;
        //     }
        //     var AdminResponceModel = new AdminResponceModel 
        //     {
        //         Message = "Admin retrieved Successfully",
        //         Status = true,
        //         Data = new AdminDto
        //         {
        //             FirstName = admgmail.FirstName,
        //             LastName = admgmail.LastName,
        //             PhoneNumber = admgmail.PhoneNumber,
        //             Email = admgmail.Email,
        //             Id = admgmail.Id,
        //             Password = admgmail.Password, 
        //         }
        //     };
        //     return AdminResponceModel;

        // }

        public  UpdateAdminRequestModel GetAdminById(int id )
        {
            var addm = _repo.Get(c => c.Id == id);
            // if (addm == null)
            // {
            //     return null;
            // }
            return new UpdateAdminRequestModel
            {

                UserId = addm.Id,
                Id = addm.Id,
                FirstName = addm.User.Email,
                LastName = addm.User.LastName,
                Email = addm.User.Email,
                PhoneNumber = addm.User.PhoneNumber,
                Password = addm.User.PhoneNumber,
                // Role = "Admin",
                // IsActive = true,
            };
        }

            // public AdminResponceModel UpdateAdmin( CreateAdminRequestModel admin ,int id)
            // {
            //         var getid = _repo.Get(x => x.Id == id);
            //         if (getid == null)
            //     {
            //         return new AdminResponceModel
            //         {
            //             Message = "failed to Update",
            //             Status = false,
            //         };
            //     }
            //     getid.User.FirstName = admin.FirstName;
            //     getid.User.LastName = admin.LastName;
            //     getid.User.Email = admin.Email;
            //     _repo.UpdateAdmin(getid);
            //     return new AdminResponceModel
            //     {
            //         Message = "successfully Updated",
            //         Status = true,
            //     };

            // }
     
        public CreateAdminRequestModel  UpdateAdmin( CreateAdminRequestModel admin , int id)
        {           
            var admins = _repo.Get(o => o.Id == id);
            if (admins == null)
            {
                return null;
            }
            admins.User.FirstName = admin.FirstName ?? admins.User.FirstName;
            admins.User.LastName = admin.LastName ?? admins.User.LastName;
            admins.User.Email = admin.Email ?? admins.User.Email;
            admins.User.Password = admin.Password ?? admins.User.Password;
            admins.User.PhoneNumber = admin.PhoneNumber ?? admins.User.PhoneNumber;
            _repo.UpdateAdmin(admins);

            return admin;

        }

    }
}