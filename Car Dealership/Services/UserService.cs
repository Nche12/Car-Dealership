using Car_Dealership.Models;
using Microsoft.EntityFrameworkCore;

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
            var userFound = await _tenantContext.Users.FirstOrDefaultAsync(x => x.Email == userCreate.Email);
            if (userFound == null)
            {
                var user = _mapper.Map<User>(userCreate);
                _tenantContext.Users.Add(user);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UserGetDto?>(user);
                serviceResponse.StatusCode = StatusCodes.Status201Created;
            }
            else
            {
                // Optionally, handle the case where the user already exists.
                // For example, you could throw an exception or return null.
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Email Address already used";
                serviceResponse.StatusCode = StatusCodes.Status409Conflict;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<UserGetDto?>> UpdateUserAsync(UserEditDto userEditDto)
        {
            var serviceResponse = new ServiceResponse<UserGetDto?>();
            var user = _mapper.Map<User>(userEditDto);
            //var userFound = _tenantContext.Users.FirstOrDefaultAsync(x => x.Id == userEditDto.Id);
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
                    //serviceResponse.Data = null;
                    //serviceResponse.Success = false;
                    //serviceResponse.Message = ex.Message;
                    //serviceResponse.StatusCode = StatusCodes.Status500InternalServerError;
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
