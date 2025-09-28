using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Employee_API_JWT.Identity
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, ApplicationDbContext>
    {
        public ApplicationRoleStore(ApplicationDbContext context,IdentityErrorDescriber errorDescriber):base(context)
        {
            
        }
    }
}
