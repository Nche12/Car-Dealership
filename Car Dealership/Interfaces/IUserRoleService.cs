namespace Car_Dealership.Interfaces
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRole>> GetUserRolesAsync();
        Task<UserRole> GetUserRoleAsync(int id);
    }
}
