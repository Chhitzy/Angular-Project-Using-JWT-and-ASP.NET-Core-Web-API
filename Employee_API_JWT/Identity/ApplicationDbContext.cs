using Employee_API_JWT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Employee_API_JWT.Identity
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
