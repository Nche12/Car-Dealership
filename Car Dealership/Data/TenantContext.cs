
namespace Car_Dealership.Data
{
    public class TenantContext : DbContext 
    {
        public TenantContext (DbContextOptions<TenantContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarMake>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<CarModel>()
                .HasIndex(u => u.Name) 
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
    }
}
