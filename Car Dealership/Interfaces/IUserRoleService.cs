namespace Car_Dealership.Interfaces
{
    public interface IUserRoleService
    {
        Task<ServiceResponse<IEnumerable<UserRoleGetDto>>> GetUserRolesAsync();
        Task<ServiceResponse<UserRoleGetDto?>> GetUserRoleAsync(int id);
        Task<ServiceResponse<UserRoleGetDto?>> AddUserRoleAsync(UserRoleCreateDto userRole);
        Task<ServiceResponse<UserRoleGetDto?>> UpdateUserRole(UserRoleEditDto userRole);
        Task<ServiceResponse<UserRoleGetDto?>> DeleteUserRoleAsync(int id);
    }
}
