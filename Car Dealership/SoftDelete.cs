//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using Microsoft.EntityFrameworkCore;
//using System.Security.AccessControl;

//namespace Car_Dealership
//{
//    public class SoftDelete
//    {
//        //in TenantContext.cs: 
//        private async Task OnBeforeSaveChangesAsync()

//        {

//            //int? userId = await GetCurrentDbUserIdAsync();



//            ChangeTracker.DetectChanges();



//            List<EntityEntry> modifiedEntities = ChangeTracker.Entries()

//                .Where(p => (p.State == EntityState.Modified ||

//                    p.State == EntityState.Added ||

//                    p.State == EntityState.Deleted))
//            .ToList();



//            foreach (EntityEntry entry in modifiedEntities)
//            {

//                if (entry.Entity is Auditable trackable)

//                {

//                    switch (entityState)

//                    {

//                        // If this is a delete operation, save the deletion timestamp, and userId of deleter

//                        case EntityState.Deleted:

//                            entry.State = EntityState.Modified;

//                            trackable.IsDeleted = true;

//                            trackable.DeletedDate = DateTime.UtcNow;

//                            //trackable.DeletedById = userId;

//                            break;



//                        // If this is an addition operation, save the userId of adder, and set IsDeleted to false

//                        case EntityState.Added:

//                            //if (!trackable.AddedById.HasValue)

//                            //{

//                            //    trackable.AddedById = userId;

//                            //}

//                            //trackable.IsDeleted = false;

//                            break;



//                        // Do not modify the 3 deleted fields, as the model might have these set to nulls,

//                        // (because it was mapped from a DTO that does not contain these fields)

//                        case EntityState.Modified:

//                            entry.Property("DeletedById").IsModified = false;

//                            entry.Property("DeletedDate").IsModified = false;

//                            break;

//                    }



//                    // Do not touch these two fields, as they are handled by the MySql database with default values.

//                    entry.Property("AddedDate").IsModified = false;

//                    entry.Property("LastModifiedDate").IsModified = false;

//                }

//            }
//        }
//    }
//}
