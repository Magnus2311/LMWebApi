using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Database.Models;

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
    }
}