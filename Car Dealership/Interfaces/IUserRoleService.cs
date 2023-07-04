namespace Car_Dealership.Interfaces
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRole>> GetUserRolesAsync();
        Task<UserRole?> GetUserRoleAsync(int id);
        Task<Result?> AddUserRoleAsync(UserRole userRole);
        Task<UserRole?> UpdateUserRole(UserRole userRole);
        Task<UserRole?> DeleteUserRoleAsync(int id);
    }
}
