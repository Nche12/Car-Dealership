
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
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var newUser = await _userService.AddUserAsync(user);
            if(newUser == null)
            {
                return Conflict("User(Email) already exists"); // Or handle the conflict as you prefer
                //return BadRequest("Email already used");
                // WHat is the difference between the 2 methods above?
                // What ways can this conflict be handled?
            } 

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id}, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var userUpdate = await _userService.UpdateUserAsync(user);
            if (userUpdate == null)
            {
                return Conflict("User not found");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteUserAsync(id);

            if(user == null)
            {
                return Conflict("User does not exist");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
