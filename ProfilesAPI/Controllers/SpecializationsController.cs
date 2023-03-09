using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Controllers;

[ApiController]
[Route("api/specializations")]
public class SpecializationsController : ControllerBase
{
    private readonly ISpecializationsService _service;

    public SpecializationsController(ISpecializationsService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDto dto)
    {
        var paginatedSpecialization = await _service.GetAllAsync(dto, HttpContext.RequestAborted);

        return Ok(paginatedSpecialization);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var specialization = await _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (specialization == null)
        {
            return BadRequest($"Specialization with Id = {id} not found");
        }

        return Ok(specialization);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SpecializationDto dto)
    {
        await _service.CreateAsync(dto, HttpContext.RequestAborted);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SpecializationDto dto)
    {
        var existingSpecialization = await _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (existingSpecialization == null)
        {
            return BadRequest($"Specialization with Id = {id} not found");
        }

        await _service.UpdateAsync(dto, HttpContext.RequestAborted);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existingSpecialization = await _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (existingSpecialization == null)
        {
            return BadRequest($"Specialization with Id = {id} not found");
        }

        await _service.DeleteAsync(id, HttpContext.RequestAborted);

        return Ok();
    }
}