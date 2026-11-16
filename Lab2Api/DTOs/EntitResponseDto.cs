namespace Lab2Api.DTOs;

public class EntityResponseDto
{
public int Id { get; set; }

public string Name { get; set; } = string.Empty;

public string Description { get; set; } = string.Empty;

public DateTime CreatedAt { get; set; }
}