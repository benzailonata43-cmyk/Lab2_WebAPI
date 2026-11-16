using Lab2Api.DTOs;

namespace Lab2Api.Services;

public interface IEntityService
{
Task<EntityResponseDto> CreateAsync(CreateEntityDto dto);

Task<PagedResultDto<EntityResponseDto>> GetAllAsync(
    int page = 1,
    int pageSize = 10,
    string? search = null);
Task<EntityResponseDto> UpdateAsync(
    int id, UpdateEntityDto dto);
}