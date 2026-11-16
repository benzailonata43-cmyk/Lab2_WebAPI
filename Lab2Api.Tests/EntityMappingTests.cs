using Lab2Api.DTOs;
using Lab2Api.Mappings;
using Lab2Api.Models;
using Xunit;

namespace Lab2Api.Tests;

public class EntityMappingTests
{
[Fact]
public void ToEntity_ShouldMapProperties()
{
var dto = new CreateEntityDto
{
Name = "Test Entity",
Description = "Test Description"
};

    var entity = dto.ToEntity();

    Assert.Equal("Test Entity", entity.Name);
    Assert.Equal("Test Description", entity.Description);
    Assert.Equal(0, entity.Id);
}

[Fact]
public void ToResponseDto_ShouldMapProperties()
{
    var entity = new Entity
    {
        Id = 1,
        Name = "Test Entity",
        Description = "Test Description"
    };

    var result = entity.ToResponseDto();

    Assert.Equal(1, result.Id);
    Assert.Equal(entity.Name, result.Name);
    Assert.Equal(entity.Description, result.Description);
    Assert.Equal(entity.CreatedAt, result.CreatedAt);
}
}