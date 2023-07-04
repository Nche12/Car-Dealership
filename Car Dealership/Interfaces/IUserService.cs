namespace Car_Dealership.Interfaces
{
    public interface IUserService
    {
        Task<Result?> AddUserAsync(UserCreateDto user);
        Task<UserGetDto?> DeleteUserAsync(int id);
        Task<UserGetDto?> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<UserGetDto?> UpdateUserAsync(UserEditDto user);
    }
}