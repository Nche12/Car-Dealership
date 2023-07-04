namespace Car_Dealership.Services
{
    public class UserService : IUserService
    {
        private readonly TenantContext _tenantContext;
        public UserService(TenantContext tenantContext)
        {
            _tenantContext = tenantContext;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _tenantContext.Users.ToArrayAsync();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await _tenantContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result?> AddUserAsync(User user)
        {
            var userFound = await _tenantContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (userFound != null)
            {
                _tenantContext.Users.Add(user);
                await _tenantContext.SaveChangesAsync();
                return new Result(StatusCodes.Status201Created, user);
            }
            else
            {
                // Optionally, handle the case where the user already exists.
                // For example, you could throw an exception or return null.
                return new Result(StatusCodes.Status409Conflict, null);//how can I return a message like "email already exists"?
            }

        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            var userFound = _tenantContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (userFound != null)
            {
                _tenantContext.Entry(user).State = EntityState.Modified;
                await _tenantContext.SaveChangesAsync();//How do you apply a try catch block here?
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            var user = await _tenantContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _tenantContext.Users.Remove(user); // How do you implement a soft delete?
                await _tenantContext.SaveChangesAsync();
                return user;
            }
            else
            {
                return null;
            }

        }
    }
}
