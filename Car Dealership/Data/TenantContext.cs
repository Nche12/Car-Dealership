
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
                .HasQueryFilter(e => !e.IsDeleted)
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<CarModel>()
                .HasIndex(u => u.Name)
                .IsUnique();


            modelBuilder.Entity<UserRole>()
                .HasIndex(u => u.Role)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(U => U.Email)
                .IsUnique();

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

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
                            break;

                        // If this is an addition operation, save the userId of adder, and set IsDeleted to false
                        case EntityState.Added:
                            if (!trackable.AddedById.HasValue)
                            {
                                trackable.AddedById = userId;
                            }
                            trackable.IsDeleted = false;
                            break;

                        // Do not modify the 3 deleted fields, as the model might have these set to nulls,
                        // (because it was mapped from a DTO that does not contain these fields)
                        case EntityState.Modified:
                            entry.Property("DeletedById").IsModified = false;
                            entry.Property("DeletedDate").IsModified = false;
                            break;
                    }

                    // Do not touch these two fields, as they are handled by the MySql database with default values.
                    entry.Property("AddedDate").IsModified = false;
                    entry.Property("LastModifiedDate").IsModified = false;
                }
            }
        }
    }
}

