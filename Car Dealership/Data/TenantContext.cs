
namespace Car_Dealership.Data
{
    public class TenantContext : DbContext 
    {
        public TenantContext (DbContextOptions<TenantContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
    }
}
