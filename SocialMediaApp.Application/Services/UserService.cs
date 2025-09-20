using SocialMediaApp.Application.Interfaces;
using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user;
    }
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAsync();
    }
}