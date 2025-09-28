using Employee_API_JWT.Identity;
using Employee_API_JWT.Models.ViewModels;

namespace Employee_API_JWT.ServiceContract
{
    public interface IUserService
    {
        Task<ApplicationUser> Authenticate(LoginVM loginVM);
    }
}
