using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Application.Interfaces;
using SocialMediaApp.Domain.Entities;
using SocialMediaApp.Infrastructure.Data;

namespace SocialMediaApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        public async Task<User?> GetByIdAsync(Guid? id)
=======
        public async Task<User?> GetByIdAsync(int id)
>>>>>>> 18e5e3d1172fe2cf736fb76f6174ebfca1eb95c8
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}