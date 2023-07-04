
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Car_Dealership.Data
{
    public class TenantContext : DbContext 
    {
        public TenantContext (DbContextOptions<TenantContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
