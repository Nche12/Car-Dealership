namespace Car_Dealership.Interfaces
{
    public interface IUserService
    {
        Task<Result?> AddUserAsync(User user);
        Task<User?> DeleteUserAsync(int id);
        Task<User?> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> UpdateUserAsync(User user);
    }
}