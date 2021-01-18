namespace LMWebApi.Database.Interfaces
{
    public interface IHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string savedPasswordHash, string currentPassowrd);
    }
}