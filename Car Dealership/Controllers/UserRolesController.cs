namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        public UserRolesController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;

        }

        [HttpGet]
        public async Task<IEnumerable<UserRole>> GetUserRoles()
        {
            return await _userRoleService.GetUserRolesAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserRole(int id)
        {
            var role = await _userRoleService.GetUserRoleAsync(id);

            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRole(UserRole userRole)
        {
            var result = await _userRoleService.AddUserRoleAsync(userRole);
            return result.ToObjectResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserRole(UserRole userRole)
        {
            var userRoleFound = await _userRoleService.UpdateUserRole(userRole);
            if(userRoleFound == null)
            {
                return Conflict("User role not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            var role = await _userRoleService.DeleteUserRoleAsync(id);
            if(role == null)
            {
                return Conflict("User role not Found");
            }
            else
            {
                return NoContent();
            }

        }

    }
}
