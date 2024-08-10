using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int userId, User user);
        Task DeleteUser(int userId);
    }
}
