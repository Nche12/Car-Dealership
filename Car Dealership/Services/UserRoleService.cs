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
    }
}
