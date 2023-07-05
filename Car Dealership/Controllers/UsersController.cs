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
        public async Task<ServiceResponse<IActionResult>> GetUser(int id)
        {
            var serviceResponse = new ServiceResponse<IActionResult>();
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User not Found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                return serviceResponse;
            }

            serviceResponse.Data = _mapper.Map<IActionResult>(user);
            serviceResponse.StatusCode = StatusCodes.Status200OK;
            return serviceResponse;
        }

        [HttpPost]
        public async Task<ServiceResponse<IActionResult>> CreateUser(UserEditDto user)
        {
            var serviceResponse = new ServiceResponse<IActionResult>();
            var newUser = await _userService.AddUserAsync(user);
            serviceResponse.Data = _mapper.Map<IActionResult>(newUser);
            return serviceResponse;
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<IActionResult>> UpdateUser(UserEditDto user)
        {
            var serviceResponse = new ServiceResponse<IActionResult>();
            var userUpdate = await _userService.UpdateUserAsync(user);
            if (userUpdate == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                return serviceResponse;
            }
            else
            {
                serviceResponse.Data = _mapper.Map<IActionResult>(userUpdate);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
                return serviceResponse;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<IActionResult>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<IActionResult>();
            var user = await _userService.DeleteUserAsync(id);

            if(user == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                serviceResponse.StatusCode = StatusCodes.Status404NotFound;
                return serviceResponse;
            }
            else
            {
                serviceResponse.Data = _mapper.Map<IActionResult>(user);
                serviceResponse.StatusCode = StatusCodes.Status204NoContent;
                return serviceResponse;
            }
        }
    }
}
