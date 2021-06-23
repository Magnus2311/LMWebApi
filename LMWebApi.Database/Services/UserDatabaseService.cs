using System.Collections.Generic;
using System.Threading.Tasks;
using LMWebApi.Common.Models.Database;
using LMWebApi.Common.Models.Global;
using LMWebApi.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        public async Task ConfirmEmailAsync(string email)
        {
            var context = new LMDbContext();
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username.ToUpper() == email.ToUpper());
            user.IsConfirmed = true;
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

        public async Task<bool> Login()
        {
            var dbUser = await FindByUsernameAsync(GlobalHelpers.CurrentUser.Username);
            return _hasher.VerifyPassword(dbUser.Password, GlobalHelpers.CurrentUser.Password) && dbUser.IsConfirmed;
        }

        public async Task<bool> TryChangePasswordAsync(string newPassword)
        {
            var context = new LMDbContext();
            var dbUser = await context.Users
                .FirstOrDefaultAsync(u => u.Username.ToUpper() == GlobalHelpers.CurrentUser.Username.ToUpper());
            dbUser.Password = _hasher.HashPassword(newPassword);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateRefreshToken(User user)
        {
            var context = new LMDbContext();
            var dbUser = await FindByUsernameAsync(user.Username);
            context.Update(dbUser);
            dbUser.RefreshTokensStr = JsonConvert.SerializeObject(user.RefreshTokens);
            context.Update(dbUser);
            await context.SaveChangesAsync();
        }
    }
}