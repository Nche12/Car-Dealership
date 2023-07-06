namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        public UserRolesController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;

        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<UserRoleGetDto>>> GetUserRoles()
        {
            return await _userRoleService.GetUserRolesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<UserRoleGetDto?>> GetUserRole(int id)
        {
            return await _userRoleService.GetUserRoleAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<UserRoleGetDto?>> CreateUserRole(UserRoleCreateDto userRole)
        {
            return await _userRoleService.AddUserRoleAsync(userRole);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<UserRoleGetDto?>> UpdateUserRole(UserRoleEditDto userRole)
        {
            return await _userRoleService.UpdateUserRole(userRole);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<UserRoleGetDto?>> DeleteUserRole(int id)
        {
            return await _userRoleService.DeleteUserRoleAsync(id);
        }

    }
}
