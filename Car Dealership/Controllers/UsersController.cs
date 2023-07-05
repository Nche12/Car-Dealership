using Car_Dealership.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Car_Dealership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<UserGetDto>>> GetUsers()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<UserGetDto?>> GetUser(int id)
        {
            return await _userService.GetUserAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<UserGetDto?>> CreateUser(UserCreateDto user)
        {
            return await _userService.AddUserAsync(user);
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<UserGetDto?>> UpdateUser(UserEditDto user)
        {
            return await _userService.UpdateUserAsync(user);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<UserGetDto?>> DeleteUser(int id)
        {
            return await _userService.DeleteUserAsync(id);
        }
    }
}
