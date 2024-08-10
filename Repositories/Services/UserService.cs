using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tunify_Platform.Repositories.Services
{
    public class UserService : IUserRepository
    {
        private readonly TunifyDbContext _context;

        public UserService(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> UpdateUser(int userId, User user)
        {
            var oldUser = await _context.Users.FindAsync(userId);
            if (oldUser != null)
            {
                // Update properties
                oldUser.UserName = user.UserName;
                oldUser.Email = user.Email;
                oldUser.JoinDate = user.JoinDate;
                oldUser.SubscriptionId = user.SubscriptionId;

                await _context.SaveChangesAsync();
                return oldUser;
            }
            return null;
        }
    }
}
