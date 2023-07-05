namespace Car_Dealership.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<UserGetDto?>> AddUserAsync(UserEditDto user);
        Task<ServiceResponse<UserGetDto?>> DeleteUserAsync(int id);
        Task<ServiceResponse<UserGetDto?>> GetUserAsync(int id);
        Task<ServiceResponse<IEnumerable<UserGetDto>>> GetUsersAsync();
        Task<ServiceResponse<UserGetDto?>> UpdateUserAsync(UserEditDto user);
    }
}