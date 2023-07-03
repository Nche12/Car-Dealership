namespace Car_Dealership.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUserNamesAsync();
    }
}
