using System.ComponentModel.DataAnnotations;
using Lab2Api.DTOs;
using Lab2Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2Api.Controllers;

[ApiController]
[Route("api/v1/entities")]
public class EntitiesController : ControllerBase
{
private readonly IEntityService _service;

public EntitiesController(IEntityService service)
{
    _service = service;
}

[HttpPost]
public async Task<IActionResult> Create(
    [FromBody] CreateEntityDto dto)
{
    try
    {
        var result = await _service.CreateAsync(dto);

        return Created(
            $"/api/v1/entities/{result.Id}",
            result);
    }
    catch (ArgumentException ex)
    {
        return BadRequest(new
        {
            error = ex.Message
        });
    }
}
[HttpGet]
public async Task<IActionResult> GetAll(
[FromQuery] int page = 1,
[FromQuery] int pageSize = 10,
[FromQuery] string? search = null)
{
var result = await _service.GetAllAsync(
page, pageSize, search);

return Ok(result);
}
/// <summary>
/// Updates an existing entity by its ID.
/// </summary>
/// <param name="id">Positive entity identifier.</param>
/// <param name="dto">New name and description.</param>
/// <returns>The updated entity.</returns>
/// <response code="200">Entity updated successfully.</response>
/// <response code="400">Invalid ID or update data.</response>
/// <response code="404">Entity not found.</response>
[HttpPut("{id}")]
[Consumes("application/json")]
[Produces("application/json")]
[ProducesResponseType(typeof(EntityResponseDto), 200)]
[ProducesResponseType(400)]
[ProducesResponseType(404)]
public async Task<IActionResult> Update(
    [FromRoute, Range(1, int.MaxValue)] int id,
    [FromBody] UpdateEntityDto dto)
{
    if (id <= 0)
{
    return BadRequest(new
    {
        message = "ID must be greater than zero"
    });
}
if (!ModelState.IsValid)
{
return BadRequest(ModelState);
}

try
{
    var result = await _service.UpdateAsync(id, dto);
    return Ok(result);
}
catch (KeyNotFoundException)
{
    return NotFound(new
    {
        message = $"Entity with ID {id} not found"
    });
}
catch (ArgumentException ex)
{
    return BadRequest(new
    {
        message = ex.Message
    });
}
}
}