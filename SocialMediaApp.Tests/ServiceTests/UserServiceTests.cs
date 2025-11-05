using Moq;
using SocialMediaApp.Application.Services;
using SocialMediaApp.Application.Interfaces;
using SocialMediaApp.Domain.Entities;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _userService = new UserService(_mockUserRepository.Object);
    }

    [Fact]
    public async Task GetUserByIdAsync_ReturnsUser_WhenUserExists()
    {
        #region Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Email = "test@example.com" };

        _mockUserRepository
            .Setup(r => r.GetByIdAsync(userId))
            .ReturnsAsync(user);
        #endregion

        #region Act
        var result = await _userService.GetUserByIdAsync(userId);
        #endregion

        #region Assert
        Assert.NotNull(result);
        Assert.Equal(user, result);
        #endregion
    }

    [Fact]
    public async Task GetUserByIdAsync_ReturnsNull_WhenUserDoesNotExist()
    {
        #region Arrange
        var userId = Guid.NewGuid();

        _mockUserRepository
            .Setup(r => r.GetByIdAsync(userId))
            .ReturnsAsync((User?)null);
        #endregion

        #region Act
        var result = await _userService.GetUserByIdAsync(userId);
        #endregion

        #region Assert
        Assert.Null(result);
        #endregion
    }

    [Fact]
    public async Task GetAllUsersAsync_ReturnsAllUsers()
    {
        #region Arrange
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Email = "user1@example.com" },
            new User { Id = Guid.NewGuid(), Email = "user2@example.com" }
        };

        _mockUserRepository
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(users);
        #endregion

        #region Act
        var result = await _userService.GetAllUsersAsync();
        #endregion

        #region Assert
        Assert.NotNull(result);
        Assert.Equal(users.Count, result.Count());
        Assert.Contains(result, u => u.Email == "user1@example.com");
        Assert.Contains(result, u => u.Email == "user2@example.com");
        #endregion
    }
}
