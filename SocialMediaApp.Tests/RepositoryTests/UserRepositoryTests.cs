using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Infrastructure.Repositories;
using SocialMediaApp.Infrastructure.Data;
using SocialMediaApp.Domain.Entities;

public class UserRepositoryTests
{
    private ApplicationDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new ApplicationDbContext(options);
    }

    [Fact]
    public async Task AddAsync_AddsUserToDatabase()
    {
        using var context = CreateDbContext();
        var repo = new UserRepository(context);
        var user = new User { Id = Guid.NewGuid(), Email = "test@example.com" };

        await repo.AddAsync(user);

        var dbUser = await context.Users.FindAsync(user.Id);
        Assert.NotNull(dbUser);
        Assert.Equal(user.Email, dbUser.Email);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsUser_WhenExists()
    {
        using var context = CreateDbContext();
        var user = new User { Id = Guid.NewGuid(), Email = "test@example.com" };
        context.Users.Add(user);
        context.SaveChanges();

        var repo = new UserRepository(context);
        var result = await repo.GetByIdAsync(user.Id);

        Assert.NotNull(result);
        Assert.Equal(user.Email, result.Email);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenNotExists()
    {
        using var context = CreateDbContext();
        var repo = new UserRepository(context);

        var result = await repo.GetByIdAsync(Guid.NewGuid());

        Assert.Null(result);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllUsers()
    {
        using var context = CreateDbContext();
        var users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Email = "user1@example.com" },
            new User { Id = Guid.NewGuid(), Email = "user2@example.com" }
        };
        context.Users.AddRange(users);
        context.SaveChanges();

        var repo = new UserRepository(context);
        var result = await repo.GetAllAsync();

        Assert.Equal(2, ((List<User>)result).Count);
    }

    [Fact]
    public async Task UpdateAsync_UpdatesUser()
    {
        using var context = CreateDbContext();
        var user = new User { Id = Guid.NewGuid(), Email = "old@example.com" };
        context.Users.Add(user);
        context.SaveChanges();

        var repo = new UserRepository(context);
        user.Email = "new@example.com";
        await repo.UpdateAsync(user);

        var updatedUser = await context.Users.FindAsync(user.Id);
        Assert.Equal("new@example.com", updatedUser.Email);
    }

    [Fact]
    public async Task DeleteAsync_RemovesUser()
    {
        using var context = CreateDbContext();
        var user = new User { Id = Guid.NewGuid(), Email = "delete@example.com" };
        context.Users.Add(user);
        context.SaveChanges();

        var repo = new UserRepository(context);
        await repo.DeleteAsync(user.Id);

        var deletedUser = await context.Users.FindAsync(user.Id);
        Assert.Null(deletedUser);
    }
}
