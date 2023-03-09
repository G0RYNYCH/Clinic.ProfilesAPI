using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Interfaces;
using ProfilesAPI.Models.Dtos;

namespace ProfilesAPI.Controllers;

[ApiController]
[Route("api/receptionists")]
public class ReceptionistsController : ControllerBase
{
    private readonly IReceptionistsService _service;

    public ReceptionistsController(IReceptionistsService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]PaginationDto dto)
    {
        var paginatedReceptionists = await _service.GetAllAsync(dto, HttpContext.RequestAborted);

        return Ok(paginatedReceptionists);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var receptionist = await _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (receptionist == null)
        {
            return BadRequest($"Receptionist with Id = {id} not found");
        }

        return Ok(receptionist);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReceptionistDto dto)
    {
        await _service.CreateAsync(dto, HttpContext.RequestAborted);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ReceptionistDto dto)
    {
        var existingReceptionist = await _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (existingReceptionist == null)
        {
            return BadRequest($"Receptionist with Id = {id} not found");
        }

        await _service.UpdateAsync(dto, HttpContext.RequestAborted);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var existingReceptionist = _service.GetByIdAsync(id, HttpContext.RequestAborted);
        if (existingReceptionist == null)
        {
            return BadRequest($"Receptionist with Id = {id} not found");
        }

        await _service.DeleteAsync(id, HttpContext.RequestAborted);

        return Ok();
    }
}