using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Infrastructure.Repositories;
using SocialMediaApp.Infrastructure.Data;
using SocialMediaApp.Domain.Entities;

public class UserRepositoryTests : IAsyncLifetime
{
    private ApplicationDbContext _context = null!;
    private UserRepository _repository = null!;

    // DB initializer (runs before each test)
    public async Task InitializeAsync()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ApplicationDbContext(options);
        _repository = new UserRepository(_context);
        await Task.CompletedTask;
    }

    // DB cleanup (runs after each test)
    public async Task DisposeAsync()
    {
        // runs AFTER each test
        await _context.Database.EnsureDeletedAsync();
        await _context.DisposeAsync();
    }

    [Fact]
    public async Task AddAsync_AddsUserToDatabase()
    {
        #region Arrange
        var user = new User { Id = Guid.NewGuid(), Email = "test@example.com" };
        #endregion

        #region Act
        await _repository.AddAsync(user);
        await _context.SaveChangesAsync();
        #endregion

        #region Assert
        var dbUser = await _context.Users.FindAsync(user.Id);
        Assert.NotNull(dbUser);
        Assert.Equal(user.Email, dbUser.Email);
        #endregion
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsUser_WhenExists()
    {
        #region Arrange
        var user = new User { Id = Guid.NewGuid(), Email = "test@example.com" };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        #endregion

        #region Act
        var result = await _repository.GetByIdAsync(user.Id);
        #endregion

        #region Assert
        Assert.NotNull(result);
        Assert.Equal(user.Email, result.Email);
        #endregion
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenNotExists()
    {
        #region Act
        var result = await _repository.GetByIdAsync(Guid.NewGuid());
        #endregion

        #region Assert
        Assert.Null(result);
        #endregion
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllUsers()
    {
        #region Arrange
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Email = "user1@example.com" },
            new User { Id = Guid.NewGuid(), Email = "user2@example.com" }
        };

        _context.Users.AddRange(users);
        await _context.SaveChangesAsync();
        #endregion

        #region Act
        var result = await _repository.GetAllAsync();
        #endregion

        #region Assert
        var list = result.ToList();
        Assert.Equal(2, list.Count);
        Assert.Contains(list, u => u.Email == "user1@example.com");
        Assert.Contains(list, u => u.Email == "user2@example.com");
        #endregion
    }

    [Fact]
    public async Task UpdateAsync_UpdatesUser()
    {
        #region Arrange
        var user = new User { Id = Guid.NewGuid(), Email = "old@example.com" };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        user.Email = "new@example.com";
        #endregion

        #region Act
        await _repository.UpdateAsync(user);
        #endregion

        #region Assert
        var updatedUser = await _context.Users.FindAsync(user.Id);
        Assert.NotNull(updatedUser);
        Assert.Equal("new@example.com", updatedUser.Email);
        #endregion
    }

    [Fact]
    public async Task DeleteAsync_RemovesUser()
    {
        #region Arrange
        var user = new User { Id = Guid.NewGuid(), Email = "delete@example.com" };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        #endregion

        #region Act
        await _repository.DeleteAsync(user.Id);
        #endregion

        #region Assert
        var deletedUser = await _context.Users.FindAsync(user.Id);
        Assert.Null(deletedUser);
        #endregion
    }
}
