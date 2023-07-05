namespace Car_Dealership.Services
{
    public class UserService : IUserService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;

        public UserService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UserGetDto>> GetUsersAsync()
        {
            var users = await _tenantContext.Users.ToArrayAsync();
            return users.Select(c => _mapper.Map<UserGetDto>(c)).ToList();// why not ToArrayAsync?
        }

        public async Task<UserGetDto?> GetUserAsync(int id)
        {
            var user = await _tenantContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UserGetDto>(user) ;
        }

        public async Task<Result?> AddUserAsync(UserCreateDto userCreateDto)
        {
            var userFound = await _tenantContext.Users.FirstOrDefaultAsync(x => x.Email == userCreateDto.Email);
            if (userFound == null)
            {
                var user = _mapper.Map<User>(userCreateDto);
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

        public async Task<UserGetDto?> UpdateUserAsync(UserEditDto userEditDto)
        {
            var userFound = _tenantContext.Users.FirstOrDefaultAsync(x => x.Id == userEditDto.Id);
            if (userFound != null)
            {
                _tenantContext.Entry(userEditDto).State = EntityState.Modified;
                await _tenantContext.SaveChangesAsync();//How do you apply a try catch block here?
                return _mapper.Map<UserGetDto>(userEditDto);
            }
            else
            {
                return null;
            }
        }

        public async Task<UserGetDto?> DeleteUserAsync(int id)
        {
            var user = await _tenantContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _tenantContext.Users.Remove(user); // How do you implement a soft delete?
                await _tenantContext.SaveChangesAsync();
                return _mapper.Map<UserGetDto>(user);
            }
            else
            {
                return null;
            }

        }
    }
}
