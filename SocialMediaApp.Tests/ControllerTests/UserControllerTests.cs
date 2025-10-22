using Moq;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Web.Controllers;
using SocialMediaApp.Application.Interfaces;
using SocialMediaApp.Domain.Entities;

public class UsersControllerTests
{
    private readonly Mock<IUserService> _mockUserService;
    private readonly UsersController _controller;

    public UsersControllerTests()
    {
        _mockUserService = new Mock<IUserService>();
        _controller = new UsersController(_mockUserService.Object);
    }

    [Fact]
    public async Task GetUser_ReturnsOk_WhenUserExists()
    {
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Email = "test@example.com" };
        _mockUserService.Setup(s => s.GetUserByIdAsync(userId)).ReturnsAsync(user);
        
        var result = await _controller.GetUser(userId);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(user, okResult.Value);
    }

    [Fact]
    public async Task GetUser_ReturnsNotFound_WhenUserDoesNotExist()
    {
        var userId = Guid.NewGuid();
        _mockUserService.Setup(s => s.GetUserByIdAsync(userId)).ReturnsAsync((User?)null);

        var result = await _controller.GetUser(userId);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsOk_WithListOfUsers()
    {
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Email = "user1@example.com" },
            new User { Id = Guid.NewGuid(), Email = "user2@example.com" }
        };
        _mockUserService.Setup(s => s.GetAllUsersAsync()).ReturnsAsync(users);

        var result = await _controller.GetAllUsers();

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(users, okResult.Value);
    }
}
