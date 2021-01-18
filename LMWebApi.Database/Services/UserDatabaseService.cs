using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace LMWebApi.Database.Services
{
    public class UserDatabaseService : IUserDatabaseService
    {
        private readonly IHashService _hasher;

        public UserDatabaseService()
        {
            _hasher = new HashService();
        }

        public async Task Add(User user)
        {
            var context = new LMDbContext();
            user.Password = _hasher.HashPassword(user.Password);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task Delete(string username)
        {
            var context = new LMDbContext();
            var dbUser = await FindByUsernameAsync(username);
            context.Users.Remove(dbUser);
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            var context = new LMDbContext();
            return await context.Users.FirstOrDefaultAsync(u => u.Username.ToUpper() == username.ToUpper());
        }

        public async Task<List<User>> GetAll()
        {
            var context = new LMDbContext();
            return await context.Users.ToListAsync();
        }

        public async Task<bool> Login(User user)
        {
            var dbUser = await FindByUsernameAsync(user.Username);
            return _hasher.VerifyPassword(dbUser.Password, user.Password);
        }

        public async Task UpdateRefreshToken(User user)
        {
            var context = new LMDbContext();
            var dbUser = await FindByUsernameAsync(user.Username);
            dbUser.RefreshTokens = user.RefreshTokens;
            await context.SaveChangesAsync();
        }
    }
}