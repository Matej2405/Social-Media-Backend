using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Application.Interfaces;

public interface IUserService
{
    Task<User?> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
}