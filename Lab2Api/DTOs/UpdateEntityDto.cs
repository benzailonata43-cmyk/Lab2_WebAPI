using System.ComponentModel.DataAnnotations;

namespace Lab2Api.DTOs;

public class UpdateEntityDto
{
[Required(ErrorMessage = "Name is required")]
[StringLength(100, MinimumLength = 2,
ErrorMessage = "Name must contain 2-100 characters")]
public string Name { get; set; } = string.Empty;

[StringLength(500,
    ErrorMessage = "Description cannot exceed 500 characters")]
public string? Description { get; set; }
}