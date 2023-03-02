using System.Linq.Expressions;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Dto.ResponceModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Services.Interface
{
    public interface IAdminServices
    {
       public CreateAdminRequestModel CreateAdmin(CreateAdminRequestModel admin);
        public UpdateAdminRequestModel GetAdminById(int id);
        void DeleteAdmin(int id);
        // IList<Admin> GetAllAdmin();
        //IList<Admin> GetAllCustomer(Expression<Func<Admin, bool>> expression);
                //  public AdminResponceModel GetAdminByEmail(string email);
        AdminResponceModel GetAllAdmin();
        //  public AdminResponceModel UpdateAdmin( CreateAdminRequestModel admin ,int id);
                public CreateAdminRequestModel  UpdateAdmin( CreateAdminRequestModel admin ,int id);



    }
}