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

    }
}
