using Microsoft.AspNetCore.Http.HttpResults;

namespace Car_Dealership.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;

        public UserRoleService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<UserRoleGetDto>>> GetUserRolesAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<UserRoleGetDto>>();

            var userRoles = await _tenantContext.UserRoles.ToArrayAsync();
            serviceResponse.Data = userRoles.Select(c => _mapper.Map<UserRoleGetDto>(c)).ToList();
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserRoleGetDto?>> GetUserRoleAsync(int id)
        {
            var serviceResponse = new ServiceResponse<UserRoleGetDto?>();
            var userRole = await _tenantContext.UserRoles.FirstOrDefaultAsync(x => x.Id == id);
            if(userRole == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Role not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
            } 
            else
            {
                serviceResponse.Data = _mapper.Map<UserRoleGetDto>(userRole);
                serviceResponse.StatusCode = StatusCodes.Status200OK;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserRoleGetDto?>> AddUserRoleAsync(UserRoleCreateDto userRoleCreateDto)
        {
            var serviceResponse = new ServiceResponse<UserRoleGetDto?>();
            //var roleUsed = await _tenantContext.UserRoles.FirstOrDefaultAsync(r => r.Role == userRoleCreateDto.Role);

            //if (roleUsed == null)
            //{
                var userRole = _mapper.Map<UserRole>(userRoleCreateDto);
                _tenantContext.UserRoles.Add(userRole);

                try
                {
                    await _tenantContext.SaveChangesAsync();
                    serviceResponse.Data = _mapper.Map<UserRoleGetDto>(userRole);
                    serviceResponse.StatusCode = StatusCodes.Status201Created; 
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException != null && ex.InnerException.Message.Equals($"Cannot insert duplicate key row in object 'dbo.UserRoles' with unique index 'IX_UserRoles_Role'. The duplicate key value is ({userRole.Role})."))
                {
                        serviceResponse.Data = null;
                        serviceResponse.Success = false;
                        serviceResponse.Message = $"'{userRole.Role}' already exists";
                        serviceResponse.StatusCode = StatusCodes.Status409Conflict;
                    }
                    else
                    {
                        throw;
                    }
                }
            //}
            //else
            //{
            //    serviceResponse.Data = null;
            //    serviceResponse.Success = false;
            //    serviceResponse.Message = "Role already exists";
            //    serviceResponse.StatusCode = StatusCodes.Status409Conflict;
            //}

            return serviceResponse;
        }

        public async Task<ServiceResponse<UserRoleGetDto?>> UpdateUserRole(UserRoleEditDto userRoleEditDto)
        {
            var serviceResponse = new ServiceResponse<UserRoleGetDto?>();
            var userRole = _mapper.Map<UserRole>(userRoleEditDto);
            _tenantContext.Entry(userRole).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UserRoleGetDto>(userRole);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!UserRoleExists(userRole.Id))
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Role not found";
                    serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                } 
                else
                {
                    throw;
                }
                
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<UserRoleGetDto?>> DeleteUserRoleAsync(int id)
        {
            var serviceResponse = new ServiceResponse<UserRoleGetDto?>();
            var role = await _tenantContext.UserRoles.FirstOrDefaultAsync(x => x.Id == id);
            if (role != null)
            {
                _tenantContext.Remove(role);
                await _tenantContext.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UserRoleGetDto>(role);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Role not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
            }
            return serviceResponse;

        }

        private bool UserRoleExists(int id)
        {
            return _tenantContext.UserRoles.Any(x => x.Id == id);
        }


    }
}
