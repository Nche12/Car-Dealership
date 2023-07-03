
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly TenantContext _tenantContext;
        private readonly UserService _userService;
        public UsersController(TenantContext tenantContext, UserService userService)
        {
            _tenantContext = tenantContext;
            _userService = userService;
         }

        [HttpGet]
        public async Task<IEnumerable<User>> getUsers()
        {
            return await _userService.GetUsersAsync();
        }
    }
}
