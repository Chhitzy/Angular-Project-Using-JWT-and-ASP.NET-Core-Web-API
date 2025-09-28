using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Employee_API_JWT.Identity
{
    public class ApplicationUserStore:UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context):base (context)
        {
            
        }
    }
}
