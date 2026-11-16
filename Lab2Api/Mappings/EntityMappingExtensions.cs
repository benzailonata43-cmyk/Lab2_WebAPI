using Lab2Api.DTOs;
using Lab2Api.Models;

namespace Lab2Api.Mappings;

public static class EntityMappingExtensions
{
public static Entity ToEntity(this CreateEntityDto dto)
{
return new Entity
{
Name = dto.Name,
Description = dto.Description ?? string.Empty
};
}

public static EntityResponseDto ToResponseDto(this Entity entity)
{
    return new EntityResponseDto
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        CreatedAt = entity.CreatedAt
    };
}
}