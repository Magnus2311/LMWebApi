using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;

namespace LMWebApi.Database.Interfaces
{
    public interface IUserDatabaseService
    {
        Task Add(User user);
        Task<List<User>> GetAll();
        Task<bool> Login(User user);
        Task<User> FindByUsernameAsync(string username);
        Task UpdateRefreshToken(User user);
        Task Delete(string username);
        Task ConfirmEmailAsync(string email);
        Task<bool> TryChangePasswordAsync(User user, string newPassword);
    }
}