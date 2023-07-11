
using Car_Dealership.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Car_Dealership.Data
{
    public class TenantContext : DbContext
    {
        public TenantContext(DbContextOptions<TenantContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarMake>()
                .HasQueryFilter(e => e.IsDeleted == null || e.IsDeleted == false)
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<CarModel>()
                .HasQueryFilter(e => e.IsDeleted == null || e.IsDeleted == false)
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .HasQueryFilter(e => e.IsDeleted == null || e.IsDeleted == false)
                .HasIndex(u => u.Role)
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .HasMany(ur => ur.Users)
                .WithOne(u => u.UserRole)
                .HasForeignKey(ur => ur.UserRoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(u => u.AddedBy)
                .WithMany(u => u.UserRolesAdded)
                .HasForeignKey(u => u.AddedById);

            modelBuilder.Entity<UserRole>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.UserRolesDeleted)
                .HasForeignKey(u => u.DeletedById);

            modelBuilder.Entity<User>()
                .HasQueryFilter(e => e.IsDeleted == null || e.IsDeleted == false)
                .HasIndex(U => U.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserRole)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.UserRoleId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.AddedBy)
                .WithMany(u => u.UsersAdded)
                .HasForeignKey(u => u.AddedById);

            modelBuilder.Entity<User>()
                .HasOne(u => u.DeletedBy)
                .WithMany(u => u.UsersDeleted)
                .HasForeignKey(u => u.DeletedById);

            modelBuilder.Entity<TransmissionType>()
                .HasQueryFilter(t => t.IsDeleted == null || t.IsDeleted == false)
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<FuelType>()
                .HasQueryFilter(f => f.IsDeleted == null || f.IsDeleted == false) 
                .HasIndex(f => f.Name)
                .IsUnique();

            modelBuilder.Entity<SeatType>()//Deleted type can not be created again ???
                .HasQueryFilter(s => s.IsDeleted == null || s.IsDeleted == false)
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<CarType>()
                .HasQueryFilter(c => c.IsDeleted == null || c.IsDeleted == false) 
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<CarDriveType>()
                .HasQueryFilter(c => c.IsDeleted == null && c.IsDeleted == false);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<CarDriveType> CarDriveTypes { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await onBeforeSaveChangesAsync();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private async Task onBeforeSaveChangesAsync()
        {
            var userId = 1; //For now need a dummy userId
            ChangeTracker.DetectChanges();
            List<EntityEntry> modifiedEntries = ChangeTracker.Entries()
                .Where(p => (p.State == EntityState.Modified ||
                 p.State == EntityState.Added ||
                 p.State == EntityState.Deleted))
                .ToList();
            foreach (EntityEntry entry in modifiedEntries)
            {
                EntityState entityState = entry.State;

                if (entry.Entity is Auditable trackable)
                {
                    switch (entityState)
                    {
                        // If this is a delete operation, save the deletion timestamp, and userId of deleter
                        case EntityState.Deleted:
                            entry.Reload();
                            entry.State = EntityState.Modified;
                            trackable.IsDeleted = true;
                            trackable.DeletedDate = DateTime.UtcNow;
                            trackable.DeletedById = userId;
                            entry.Property("LastModifiedDate").IsModified = false;
                            entry.Property("AddedDate").IsModified = false;
                            break;

                        // If this is an addition operation, save the userId of adder, and set IsDeleted to false
                        case EntityState.Added:
                            if (!trackable.AddedById.HasValue)
                            {
                                trackable.AddedById = userId;
                                trackable.AddedDate = DateTime.UtcNow;
                            }
                            trackable.IsDeleted = false;
                            break;

                        // Do not modify the 3 deleted fields, as the model might have these set to nulls,
                        // (because it was mapped from a DTO that does not contain these fields)
                        case EntityState.Modified:
                            entry.Property("DeletedById").IsModified = false;
                            entry.Property("DeletedDate").IsModified = false;
                            entry.Property("AddedById").IsModified = false;
                            entry.Property("AddedDate").IsModified = false;
                            trackable.LastModifiedDate = DateTime.UtcNow;
                            break;
                    }
                    
                }
            }
        }
    }
}

