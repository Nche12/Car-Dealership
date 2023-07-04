
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserGetDto>> GetUsers()
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
        public async Task<IActionResult> CreateUser(UserCreateDto user)
        {
            var result = await _userService.AddUserAsync(user);
            return result.ToObjectResult();
            //if(response.StatusCodes == StatusCodes.Status409Conflict)
            //{
            //    return Conflict("User(Email) already exists"); // Or handle the conflict as you prefer
            //    //return BadRequest("Email already used");
            //    // WHat is the difference between the 2 methods above?
            //    // What ways can this conflict be handled?
            //} 

            //return CreatedAtAction(nameof(GetUser), new { id = ((User)(response.Response)).Id}, response.Response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UserEditDto user)
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
