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
        #region Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Email = "test@example.com" };

        _mockUserService
            .Setup(s => s.GetUserByIdAsync(userId))
            .ReturnsAsync(user);
        #endregion

        #region Act
        var result = await _controller.GetUser(userId);
        #endregion

        #region Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(user, okResult.Value);
        #endregion
    }

    [Fact]
    public async Task GetUser_ReturnsNotFound_WhenUserDoesNotExist()
    {
        #region Arrange
        var userId = Guid.NewGuid();

        _mockUserService
            .Setup(s => s.GetUserByIdAsync(userId))
            .ReturnsAsync((User?)null);
        #endregion

        #region Act
        var result = await _controller.GetUser(userId);
        #endregion

        #region Assert
        Assert.IsType<NotFoundResult>(result);
        #endregion
    }

    [Fact]
    public async Task GetAllUsers_ReturnsOk_WithListOfUsers()
    {
        #region Arrange
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Email = "user1@example.com" },
            new User { Id = Guid.NewGuid(), Email = "user2@example.com" }
        };

        _mockUserService
            .Setup(s => s.GetAllUsersAsync())
            .ReturnsAsync(users);
        #endregion

        #region Act
        var result = await _controller.GetAllUsers();
        #endregion

        #region Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(users, okResult.Value);
        #endregion
    }
}
