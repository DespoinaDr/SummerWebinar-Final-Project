using SummerWebinarApp.Data;

namespace SummerWebinarApp.Repositories
{
    // Interface defining repository operations specific to users
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(string username, string password);
        Task<User?> UpdateUserAsync(int userId, User request);
        Task<User?> GetByUsernameAsync(string username);
        Task<List<User>> GetAllUsersFilteredAsync(int pageNumber, int pageSize,
            List<Func<User, bool>> predicates);
    }
}
