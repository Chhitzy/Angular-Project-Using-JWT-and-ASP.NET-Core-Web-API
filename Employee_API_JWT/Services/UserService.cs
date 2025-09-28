using Employee_API_JWT.Identity;
using Employee_API_JWT.Models.ViewModels;
using Employee_API_JWT.ServiceContract;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employee_API_JWT.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationSignInManager _applicationSignInManager;
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly AppSettings _appSettings;


        public UserService(ApplicationSignInManager applicationSignInManager, ApplicationUserManager applicationUserManager, IOptions<AppSettings> appSettings)
        {
            _applicationSignInManager = applicationSignInManager;
            _applicationUserManager = applicationUserManager;
            _appSettings = appSettings.Value;
        }
        public async Task<ApplicationUser> Authenticate(LoginVM loginVM)
        {
            var result = await _applicationSignInManager.PasswordSignInAsync(loginVM.username, loginVM.password,false,false);
            if (result.Succeeded)
            {
                var applicationUser = await _applicationUserManager.FindByNameAsync(loginVM.username);
                applicationUser.PasswordHash = "";
                //JWT IMPLEMENTATION HERE
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim (ClaimTypes.Name, applicationUser.Id.ToString()),
                    new Claim (ClaimTypes.Role, applicationUser.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(2),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                applicationUser.Token = tokenHandler.WriteToken(token);

                
                // -_-

                return applicationUser;
            }
            return null;
        }
    }
}
