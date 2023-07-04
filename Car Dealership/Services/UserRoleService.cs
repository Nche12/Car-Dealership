using Microsoft.AspNetCore.Http.HttpResults;

namespace Car_Dealership.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly TenantContext _tenantContext;

        public UserRoleService(TenantContext tenantContext) 
        { 
            _tenantContext = tenantContext;
        }
        public async Task<IEnumerable<UserRole>> GetUserRolesAsync()
        {
            return await _tenantContext.UserRoles.ToArrayAsync();
        }

        public async Task<UserRole?> GetUserRoleAsync(int id)
        {
            return await _tenantContext.UserRoles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result?> AddUserRoleAsync(UserRole userRole)
        {
            var roleFound = _tenantContext.UserRoles.FirstOrDefaultAsync(x => x.Role == userRole.Role);
            if (roleFound != null)
            {
                _tenantContext.UserRoles.Add(userRole);
                await _tenantContext.SaveChangesAsync();
                return new Result(StatusCodes.Status201Created, userRole);
            } 
            else
            {
                return new Result(StatusCodes.Status409Conflict, null);
            }
            
        }

        public async Task<UserRole?> UpdateUserRole(UserRole userRole)
        {
            var userRoleFound = _tenantContext.UserRoles.FirstOrDefault(x => x.Id == userRole.Id);
            if(userRoleFound != null)
            {
                _tenantContext.Entry(userRole).State = EntityState.Modified;
                await _tenantContext.SaveChangesAsync();
                return userRole;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<UserRole?> DeleteUserRoleAsync(int id)
        {
            var roleFound = await _tenantContext.UserRoles.FirstOrDefaultAsync(x => x.Id == id);
            if (roleFound != null)
            {
                _tenantContext.Remove(roleFound);
                await _tenantContext.SaveChangesAsync();
                return roleFound;
            }
            else
            {
                return null;
            }
        }


    }
}
