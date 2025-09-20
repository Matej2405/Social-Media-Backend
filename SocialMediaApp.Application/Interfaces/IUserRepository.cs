using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid? id);
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}