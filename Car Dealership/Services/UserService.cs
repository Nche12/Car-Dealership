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


        public async Task<ServiceResponse<IEnumerable<UserGetDto>>> GetUsersAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<UserGetDto>>();
            var users = await _tenantContext.Users
                .Include(c => c.UserRole)
                .ToArrayAsync();
            serviceResponse.Data = users.Select(c => _mapper.Map<UserGetDto>(c)).ToList();// why not ToArrayAsync?
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserGetDto?>> GetUserAsync(int id)
        {
            var serviceResponse = new ServiceResponse<UserGetDto?>();
            var user = await _tenantContext.Users
                .Include(c => c.UserRole)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                serviceResponse.StatusCode = StatusCodes.Status200OK;
                serviceResponse.Data = _mapper.Map<UserGetDto>(user);
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<UserGetDto?>> AddUserAsync(UserCreateDto userCreate)
        {
            var serviceResponse = new ServiceResponse<UserGetDto?>();
            var user = _mapper.Map<User>(userCreate);
            _tenantContext.Users.Add(user);
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UserGetDto?>(user);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Equals($"Cannot insert duplicate key row in object 'dbo.Users' with unique index 'IX_Users_Email'. The duplicate key value is ({user.Email})."))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Email Address '{user.Email}' is already used";
                    serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                }
                else
                {
                    throw;
                }

            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<UserGetDto?>> UpdateUserAsync(UserEditDto userEditDto)
        {
            var serviceResponse = new ServiceResponse<UserGetDto?>();
            var user = _mapper.Map<User>(userEditDto);
            _tenantContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();//How do you apply a try catch block here?
                var userGetDto = _mapper.Map<UserGetDto>(user);
                serviceResponse.Data = userGetDto;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "User not found";
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    throw;
                }
            }

            return serviceResponse;
        }

        private bool UserExists(int id)
        {
            return _tenantContext.Users.Any(e => e.Id == id);
        }

        public async Task<ServiceResponse<UserGetDto?>> DeleteUserAsync(int id)
        {
            var serviceResponse = new ServiceResponse<UserGetDto?>();
            var user = await _tenantContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _tenantContext.Users.Remove(user); // How do you implement a soft delete?
                await _tenantContext.SaveChangesAsync();
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
                serviceResponse.Data = _mapper.Map<UserGetDto>(user);
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
            }

            return serviceResponse;

        }
    }
}
