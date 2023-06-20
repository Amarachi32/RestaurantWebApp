using Contracts.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IUserService
    {
        //  Task<ApiResponse> AddUser(User user);
        Task<ApiResponse> DeleteAsync(string userId);
     //   Task<ApiResponse> Update(User user);
        // Task<User> GetUserByAccount(int userId);
        Task<User> GetUserByIdAsync(string userId);
        // Task<List<User>> GetUsers();
        Task<IEnumerable<User>> GetAllUsersAsync();
/*        Task<ApiResponse> ValidateEmail(string email);
        Task<ApiResponse> UpdatePassword(int userId, string newPassword);
        Task<ApiResponse> ValidatePassword(int userId, string password);*/
    }
}
