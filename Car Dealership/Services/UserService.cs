
using Microsoft.EntityFrameworkCore;

namespace Car_Dealership.Services
{
    public class UserService 
    {
        private readonly TenantContext _tenantContext;
        public UserService( TenantContext tenantContext) 
        { 
            _tenantContext = tenantContext;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _tenantContext.Users.ToArrayAsync();
        }
    }
}
