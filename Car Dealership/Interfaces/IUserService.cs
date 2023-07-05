﻿namespace Car_Dealership.Interfaces
{
    public interface IUserService
    {
        Task<Result?> AddUserAsync(UserEditDto user);
        Task<UserGetDto?> DeleteUserAsync(int id);
        Task<UserGetDto?> GetUserAsync(int id);
        Task<IEnumerable<UserGetDto>> GetUsersAsync();
        Task<UserGetDto?> UpdateUserAsync(UserEditDto user);
    }
}