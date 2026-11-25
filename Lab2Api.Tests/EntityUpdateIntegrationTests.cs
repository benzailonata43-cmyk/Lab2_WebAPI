using Lab2Api.DTOs;
using Lab2Api.Models;
using Lab2Api.Services;
using Lab2Api.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Lab2Api.Tests;

public class EntityUpdateIntegrationTests
{
[Fact]
public async Task UpdateAsync_SavesChangesToDatabase()
{
// Arrange
using var connection =
new SqliteConnection("Data Source=:memory:");

    await connection.OpenAsync();

    var options =
        new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;

    var createdAt = new DateTime(
        2026, 11, 25, 10, 0, 0, DateTimeKind.Utc);

    int entityId;

    await using (var context = new AppDbContext(options))
    {
        await context.Database.EnsureCreatedAsync();

        var entity = new Entity
        {
            Name = "Original Name",
            Description = "Original Description",
            CreatedAt = createdAt
        };

        context.Entities.Add(entity);
        await context.SaveChangesAsync();

        entityId = entity.Id;
    }

    // Act
    await using (var context = new AppDbContext(options))
    {
        var service = new EntityService(context);

        await service.UpdateAsync(
            entityId,
            new UpdateEntityDto
            {
                Name = "Updated Name",
                Description = "Updated Description"
            });
    }

    // Assert
    await using (var context = new AppDbContext(options))
    {
        var updated = await context.Entities
            .AsNoTracking()
            .SingleAsync(e => e.Id == entityId);

        Assert.Equal(entityId, updated.Id);
        Assert.Equal("Updated Name", updated.Name);
        Assert.Equal("Updated Description", updated.Description);
        Assert.Equal(createdAt, updated.CreatedAt);
    }
}
}